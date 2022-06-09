using Cronos;
using SmartHome.Database.Models;
using SmartHome.Database.Repositories;
using SmartHome.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.App
{
    public class ScheduleManagement : BaseManagement
    {        
        public ScheduleManagement(User user) : base(user) { }


        public void DeleteSchedule()
        {
            using var repo = new GenericRepository<Schedule>();

            Console.Clear();
            Console.WriteLine("Which schedule do you want to remove?");

            var schedule = SelectSchedule();
            if (schedule == null)
            {
                Console.Clear();
                Console.WriteLine("There is no such given number of device");
                Console.ReadKey();
                return;
            }
            repo.Delete(schedule.Id);

            Console.Clear();
            Console.WriteLine($"Schedule correctly deleted!");
            Console.ReadKey();
        }

        public void AddScheduleConsole()
        {
            using var repo = new GenericRepository<Schedule>();

            Console.Clear();
            var device = SelectDevice();
            if(device == null)
                return;

            var isRecuring = RecuringInput();

            var executionTime = "";
            if(isRecuring)
            {
                executionTime = CRONInput();
            }
            else
            {
                executionTime = ExecutionDateInput();
            }

            var state = StateInput();

            repo.Add(new Schedule()
            {
                DeviceId = device.Id,
                ExecutionTime = executionTime,
                IsRecurring = isRecuring,
                State = state,
                CreatedBy = _user.UserName,
                UpdatedBy = _user.UserName
            });

            Console.Clear();
            Console.WriteLine("Schedule added successfully!");
            Console.ReadKey();
        }

        private bool RecuringInput()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Is recurring (true/false):");
                var input = Console.ReadLine();
                bool result = false;
                if (bool.TryParse(input, out result))
                    return result;
                
                Console.Clear();
                Console.WriteLine("Wrong format!");
            }
        }

        private bool StateInput()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("State (on/off):");
                var input = Console.ReadLine();
                if (input.ToLower() == "on")
                    return true;

                if (input.ToLower() == "off")
                    return false;
                
                Console.Clear();
                Console.WriteLine("Wrong format!");
            }
        }

        private string ExecutionDateInput()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Enter execution date (dd/MM/yyyy HH:mm:ss):");
                var input = Console.ReadLine();
                try
                {
                    DateTime result = DateTime.ParseExact(input, "dd/MM/yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
                    return input;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong format!");
                }
            }
        }

        private string CRONInput()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Enter execution time in CRON format (mm hh dm mm dy):");
                var input = Console.ReadLine();
                try
                {
                    CronExpression expression = CronExpression.Parse(input);
                    return input;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong format!");
                }
            }
        }        
    }
}
