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
    class DeviceManagement : BaseManagement
    {        
        public DeviceManagement(User user) : base(user) { }
        public void ListDevices()
        {
            using var repo = new GenericRepository<Device>();
            var devices = repo.GetAll();
            Console.Clear();
            for(int i = 0; i < devices.Count; i++)
            {
                Device device = devices[i];
                Console.WriteLine($"{i + 1}. {device.Name}");
            }
        }

        public void SetDeviceState()
        {
            using var repo = new GenericRepository<Device>();
            Console.Clear();
            Console.WriteLine("Which device state you want to update?");

            var device = SelectDevice();
            if (device == null)
            {
                Console.Clear();
                Console.WriteLine("There is no such device");
                Console.ReadKey();
                return;
            }
            var stringState = device.State ? "On" : "Off";

            Console.WriteLine($"Current stae is: {stringState}");
            Console.WriteLine("Switch it? (yes / no)");

            var response = Console.ReadLine();

            if(response == "yes")
            {
                device.State = !device.State;
                repo.Update(device);
            }

        }
        public void AddDevice()
        {
            using var repo = new GenericRepository<Device>();

            var deviceName = InputDeviceName();
            if(deviceName == null)
                return;

            var ipString = InputDeviceIp();
            if (ipString == null)
                return;

            var deviceManual = InputDeviceManual();

            repo.Add(new Device()
            {
                Name = deviceName,
                Ip = ipString,
                InstructionManualLink = deviceManual,
                State = false,
                CreatedBy = _user.UserName,
                UpdatedBy = _user.UserName
            });

            Console.Clear();
            Console.WriteLine("Device added successfully!");
            Console.ReadKey();
        }

        private string InputDeviceName()
        {
            Console.Clear();
            Console.WriteLine("Please type the device name:");
            var deviceName = Console.ReadLine();

            if (string.IsNullOrEmpty(deviceName))
            {
                Console.WriteLine("Empty device name");
                Console.ReadKey();
                return null;
            }
            return deviceName;
        }

        private string InputDeviceIp()
        {
            Console.Clear();
            Console.WriteLine("Enter device IP:");
            var ipString = Console.ReadLine();
            IPAddress deviceIP;
            if (!IPAddress.TryParse(ipString, out deviceIP))
            {
                Console.WriteLine("Wrong ip address");
                Console.ReadKey();
                return null;
            }
            return ipString;
        }

        private string InputDeviceManual()
        {
            Console.Clear();
            Console.WriteLine("If there is some kind of instruction manual please type:");
            return Console.ReadLine();
        }

        public void EditDevice()
        {
            using var repo = new GenericRepository<Device>();

            Console.Clear();
            Console.WriteLine("Which device you wish to be changed?");
            var device = SelectDevice();
            if (device == null)
            {
                Console.Clear();
                Console.WriteLine("There is no such given number of device");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("What do you wish to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Ip");
            Console.WriteLine("3. Instruction manual address");
            Console.WriteLine("Any other response will be treated as no change");

            var responseString = Console.ReadLine();
            int response = 0;
            if (!int.TryParse(responseString, out response))
                return;


            switch (response)
            {
                case 1:
                    device.Name = InputDeviceName();
                    break;
                case 2:
                    device.Ip = InputDeviceIp();
                    break;
                case 3:
                    device.InstructionManualLink = InputDeviceManual();
                    break;
                default:
                    return;
            }
            repo.Update(device);

            Console.Clear();
            Console.WriteLine("Device updated successfully!");
            Console.ReadKey();
        }
        public void DeleteDevice()
        {
            using var repo = new GenericRepository<Device>();

            Console.Clear();
            Console.WriteLine("Which device do you want to remove?");

            var device = SelectDevice();
            if(device == null)
            {
                Console.Clear();
                Console.WriteLine("There is no such given number of device");
                Console.ReadKey();
                return;
            }
            repo.Delete(device.Id);

            Console.Clear();
            Console.WriteLine($"Deleting {device.Name}");
            Console.ReadKey();
        }
    }
}
