using System;
using static System.Console;
namespace Packet.Shared
{
    public class Employee : Person
    {
        //扩展类
        public string EmployeeCode
        {
            get;
            set;
        }

        public DateTime HireDate
        {
            get;
            set;
        }

        //隐藏成员：使用new关键字隐藏成员
        public new void WriteToConsole()
        {
            WriteLine(format:
                "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
                arg0:Name,
                arg1:DateOfBirth,
                arg2:HireDate);
        }

        //覆盖成员：使用override覆盖成员
        public override string ToString()
        {
            //return $"{Name} is a {base.ToString()}";
            return $"{Name}'s code is {EmployeeCode}";
        }

    }
}