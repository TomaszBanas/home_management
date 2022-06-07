using System;
using System.Collections.Generic;
using System.Linq;
public enum Test
{
    None = 0,
    A = 1,
    B = 2,
}
public class Program
{
    public static void Main(string[] args)
    {
        var a = new List<int> { };
        a.Select(x => 1).ToList();

        var values = new List<Test>(Enum.GetValues(typeof(Test)).Cast<Test>()).Select(x => new { Key = Convert.ToInt32(x), Value = x.ToString() });
        var data = string.Join(":", values.Select(x => x.Key + "|" + x.Value));
        Console.WriteLine(data);
    }
}

