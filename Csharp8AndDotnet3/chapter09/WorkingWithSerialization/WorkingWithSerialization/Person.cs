using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Packt.Shared
{
    public class Person
    {
        public Person() {} //定义无参构造函数，这个构造函数不需要左任何事，但是它必须存在，以便XmlSerializer在反序列化过程中调用它以实例化新的Person实例
        public Person(decimal initialSalary)
        {
            Salary = initialSalary;
        }
        //生成紧凑的XML
        //用[XmlAttribute]特性装饰除了children外的所有属性
        [XmlAttribute("fname")]
        public string FirstName { set; get; }
        
        [XmlAttribute("lname")]
        public string LastName { get; set; }
        
        [XmlAttribute("dob")]
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
        protected decimal Salary { get; set; }
    }
}