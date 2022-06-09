using Microsoft.EntityFrameworkCore;
using SmartHome.Database.Models;
using SmartHome.Database.Repositories;
using SmartHome.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.App
{
    public class BaseManagement
    {
        internal readonly User _user;

        public BaseManagement(User user)
        {
            _user = user;
        }

        internal Device SelectDevice()
        {
            using var repo = new GenericRepository<Device>();
            var devices = repo.GetAll();
            var array = devices.Select((device, i) => new KeyValuePair<int, string>(i + 1, device.Name)).ToList();
            var deviceIndex = ConsoleExtensions.SelectEnum(array, "Select device:");
            if(deviceIndex <= 0 || array.Count < deviceIndex )
            {
                return null;
            }
            return devices[deviceIndex - 1];
        }

        internal Schedule SelectSchedule()
        {
            using var repo = new GenericRepository<Schedule>();
            var data = repo.GetDbSet().Include("Device").Where(x => x.CreatedBy == _user.UserName).ToList();
            var array = data.Select((s, i) => new KeyValuePair<int, string>(i + 1, (s.IsRecurring ? "Recuring" : "Single") + $":{s.ExecutionTime}:{s.Device.Name}")).ToList();
            var index = ConsoleExtensions.SelectEnum(array, "Select schedule:");
            if (index <= 0 || array.Count < index)
            {
                return null;
            }
            return data[index - 1];
        }


        internal User SelectUser()
        {
            using var repo = new GenericRepository<User>();
            var users = repo.GetEnumerable().Where(x => x.CreatedBy == _user.UserName && x.UserName != _user.UserName).ToList();
            var array = users.Select((x, i) => new KeyValuePair<int, string>(i + 1, x.UserName)).ToList();
            var userIndex = ConsoleExtensions.SelectEnum(array, "Select user:");
            if (userIndex <= 0 || array.Count < userIndex)
                return null;
            var user = users[userIndex - 1];
            return user;
        }
    }
}
