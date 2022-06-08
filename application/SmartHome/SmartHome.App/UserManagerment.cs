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
            if (string.IsNullOrWhiteSpace(username))
                return;
            var array = Enum.GetValues(typeof(Group)).Cast<Group>().ToArray().Where(x => (int)x >= _user.Group).Select(x => new KeyValuePair<int, string>((int)x, x.ToString())).ToList();
            var group = (Group)ConsoleExtensions.SelectEnum(array, "Group:");
            if (group == Group.NotSet)
                return;
            Console.WriteLine("Password:");
            var password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
                return;

            using var repo = new GenericRepository<User>();
            repo.Add(new User()
            {
                UserName = username,
                Password = password,
                Group = (int)group,
                CreatedBy = _user.UserName,
                UpdatedBy = _user.UserName
            });

            Console.Clear();
            Console.WriteLine("User created successfully!");
            Console.ReadKey();
        }

        public void DeleteUserConsole()
        {
            Console.Clear();
            using var repo = new GenericRepository<User>();
            var user = SelectUser();
            if (user == null)
                return;
            repo.Delete(user.Id);

            Console.Clear();
            Console.WriteLine("User removed successfully!");
            Console.ReadKey();
        }

        public void UpdateUserConsole()
        {
            Console.Clear();
            using var repo = new GenericRepository<User>();
            var user = SelectUser();
            if (user == null)
                return;

            Console.WriteLine("User name:");
            var username = Console.ReadLine();
            Console.WriteLine("Password:");
            var password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
                return;
            user.UserName = username;
            user.Password = password;
            repo.Update(user);

            Console.Clear();
            Console.WriteLine("User updated successfully!");
            Console.ReadKey();
        }

        private User SelectUser()
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
