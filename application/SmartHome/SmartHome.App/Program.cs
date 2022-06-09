using Microsoft.EntityFrameworkCore;
using SmartHome.Database;
using SmartHome.Database.Models;
using SmartHome.Database.Repositories;
using SmartHome.Utility.Extensions;
using System;

namespace SmartHome.App
{
    public enum Modes
    {
        Wrong = 0,
        Login,
        // Jarek do later
        SetHarmonogram,
        DeleteHarmonogram,
        // Konrad do
        SetDeviceState,
        AddDevice,
        EditDevice,
        DeleteDevice,
        // Tomek do
        AddUser,
        EditUser,
        DeleteUser
    }
    /// <summary>
    /// IMPORTANT
    /// Before run app call 'update-database' on package manager console
    /// </summary>
    public static class Program
    {
        private static Modes? mode;

        private static User _user;

        public static void Login()
        {
            _user = null;
            using var repo = new GenericRepository<User>();
            while (_user == null)
            {
                Console.Clear();
                Console.WriteLine("Enter login");
                var login = Console.ReadLine();
                Console.WriteLine("Enter password");
                var password = Console.ReadLine();
                _user = repo.GetEnumerable().FirstOrDefault(x => x.UserName == login && x.Password == password);
            }
        }

        public static Modes SelectMode()
        {
            Console.Clear();
            var array = Enum.GetValues(typeof(Modes)).Cast<Modes>().ToArray().Select(x => new KeyValuePair<int, string>((int)x, x.ToString())).ToList();
            return (Modes)ConsoleExtensions.SelectEnum(array, "Select mode:");
        }

        public static void Main(string[] args)
        {
            // startup
            using (var db = new DatabaseContext())
            {
                db.Database.Migrate();
            }
            // example of db connection
            //using (var repo = new GenericRepository<EntityType>())
            //{
            //    var data = repo.GetAll();
            //    foreach (var item in data)
            //    {
            //        Console.WriteLine($"{item.Key} => {item.Name}");
            //    }
            //}

            Login();

            new ScheduleBackgrooundManagement(_user).Run();

            while (true)
            {
                var mode = SelectMode();
                switch (mode)
                {
                    case Modes.Login:
                        Login();
                        break;
                    case Modes.AddUser:
                        new UserManagerment(_user).AddUserConsole();
                        break;
                    case Modes.DeleteUser:
                        new UserManagerment(_user).DeleteUserConsole();
                        break;
                    case Modes.EditUser:
                        new UserManagerment(_user).UpdateUserConsole();
                        break;
                    case Modes.SetDeviceState:
                        new DeviceManagement(_user).SetDeviceState();
                        break;
                    case Modes.AddDevice:
                        new DeviceManagement(_user).AddDevice();
                        break;
                    case Modes.EditDevice:
                        new DeviceManagement(_user).EditDevice();
                        break;
                    case Modes.DeleteDevice:
                        new DeviceManagement(_user).DeleteDevice();
                        break;
                    case Modes.SetHarmonogram:
                        new ScheduleManagement(_user).AddScheduleConsole();
                        break;
                    case Modes.DeleteHarmonogram:
                        new ScheduleManagement(_user).DeleteSchedule();
                        break;
                }
            }
        }
    }
}