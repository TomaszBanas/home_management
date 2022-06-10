using Cronos;
using Microsoft.EntityFrameworkCore;
using SmartHome.Database.Models;
using SmartHome.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.App
{
    public class ScheduleBackgroundManagement
    {
        private readonly User _user;
        private readonly TimeSpan _intervalTimeSpan = new TimeSpan(0, 0, 10);
        
        private Timer _timer;

        public ScheduleBackgroundManagement(User user)
        {
            _user = user;
            
        }

        public void Run()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
            _timer = new Timer(new TimerCallback(ExecuteSchedule), null, (int)_intervalTimeSpan.TotalMilliseconds, (int)_intervalTimeSpan.TotalMilliseconds);
        }

        private void ExecuteSchedule(object state)
        {
            using var repo = new GenericRepository<Schedule>();
            var schedules = repo.GetDbSet().Include("Device").ToList();
            var timeNow = DateTime.UtcNow;
            var schedulesRecuring = schedules.Where(x => x.IsRecurring && IsCronSchouldExecute(x.ExecutionTime, x.CreatedOn)).ToList();
            var schedulesNotRecuring = schedules.Where(x => !x.IsRecurring && DateTime.ParseExact(x.ExecutionTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")) <= DateTime.Now).ToList();
            var all = schedulesRecuring.Concat(schedulesNotRecuring);
            if (!all.Any())
                return;
            
            foreach (var item in all)
            {
                item.Device.State = item.State;
                item.SetUpdated();
                repo.SaveChanges();
            }

            if (!schedulesNotRecuring.Any())
                return;
            
            foreach (var item in schedulesNotRecuring)
                repo.Delete(item.Id);
            repo.SaveChanges();
        }

        private bool IsCronSchouldExecute(string time, DateTime createdOn)
        {
            CronExpression expression = CronExpression.Parse(time);
            IEnumerable<DateTime> occurrences = expression.GetOccurrences(
                createdOn.ToUniversalTime(),
                DateTime.UtcNow.Add(_intervalTimeSpan),
                fromInclusive: true,
                toInclusive: true);
            if (!occurrences.Any())
                return false;
            return occurrences.Last() >= DateTime.UtcNow;
        }

    }
}
