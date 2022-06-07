using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Utility.Extensions
{
    public static class ConsoleExtensions
    {
        public static int SelectEnum(List<KeyValuePair<int, string>> array, string message)
        {
            Console.WriteLine(String.Join("\n\r", array.Where(x => x.Key > 0).Select(x => $"{x.Key}. {x.Value}")));
            Console.WriteLine(message);
            var modeString = Console.ReadLine();
            int mode = 0;
            int.TryParse(modeString, out mode);
            return mode;
        }
    }
}
