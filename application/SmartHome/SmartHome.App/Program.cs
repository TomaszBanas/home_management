using SmartHome.Database.Models;
using SmartHome.Database.Repositories;
using System;

namespace SmartHome.App
{
    public enum Modes
    {
        Wrong = 0,
        Login,
        // Jarek do later
        SetHarmonogram,
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

        private static string _userName;

        public static void Login()
        {
            _userName = null;
            while (string.IsNullOrWhiteSpace(_userName))
            {
                Console.Clear();
                Console.WriteLine("Enter login");
                var login = Console.ReadLine();
                Console.WriteLine("Enter passord");
                var password = Console.ReadLine();
                if(login == "admin" && password == "admin") // check with db
                {
                    _userName = login;
                }
            }
        }

        public static Modes SelectMode()
        {
            Console.Clear();
            var array = Enum.GetValues(typeof(Modes)).Cast<Modes>().ToArray();
            Console.WriteLine(String.Join("\n\r", array.Where(x => x > 0).Select(x => $"{(int)x}. {x.ToString()}")));
            Console.WriteLine("Select mode:");
            var modeString = Console.ReadLine();
            int mode = 0;
            int.TryParse(modeString, out mode);
            return (Modes)mode;
        }

        public static void Main(string[] args)
        {
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
            while (true)
            {
                var mode = SelectMode();
                switch (mode)
                {
                    case Modes.Login:
                        Login();
                        break;
                    //case Modes.InsertUser:
                    //    InsertUser();
                    //    break;
                    //case Modes.InsertDevice:
                    //    InsertDevice();
                    //    break;
                    //case Modes.DeleteUser:
                    //    DeleteUser();
                    //    break;
                    //case Modes.DeleteDevice:
                    //    DeleteDevice();
                    //    break;
                }
            }
        }
    }
}