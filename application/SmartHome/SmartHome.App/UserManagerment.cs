using SmartHome.Database.Models;
using SmartHome.Database.Repositories;
using SmartHome.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.App
{
    public enum Group
    {
        NotSet = 0,
        Admin = 1,
        User = 2,
        Guest = 3,
    }
    public class UserManagerment
    {
        private readonly User _user;

        public UserManagerment(User user)
        {
            _user = user;
        }

        public void AddUserConsole()
        {
            Console.Clear();
            Console.WriteLine("User name:");
            var username = Console.ReadLine();
            var array = Enum.GetValues(typeof(Group)).Cast<Group>().ToArray().Where(x => (int)x >= _user.Group).Select(x => new KeyValuePair<int, string>((int)x, x.ToString())).ToList();
            var group = (Group)ConsoleExtensions.SelectEnum(array, "Group:");
            Console.WriteLine("Password:");
            var password = Console.ReadLine();

            using var repo = new GenericRepository<User>();
            repo.Add(new User()
            {
                UserName = username,
                Password = password,
                Group = (int)group,
                CreatedBy = _user.UserName,
                UpdatedBy = _user.UserName
            });
        }
    }
}
