using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class Person
    {
        public Person() {} //定义无参构造函数，这个构造函数不需要左任何事，但是它必须存在，以便XmlSerializer在反序列化过程中调用它以实例化新的Person实例
        public Person(decimal initialSalary)
        {
            Salary = initialSalary;
        }
        public string FirstName { set; get; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
        protected decimal Salary { get; set; }
    }
}