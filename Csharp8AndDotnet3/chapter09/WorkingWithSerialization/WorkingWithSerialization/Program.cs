using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Packt.Shared;
using static System.Environment;
using static System.IO.Path;
using static System.Console;
using System.Threading.Tasks;
using NuJson = System.Text.Json.JsonSerializer;

namespace WorkingWithSerialization
{
    class Program
    {
        //static void Main(string[] args)
        //通过将void改为async Task以支持等待任务
        static async Task Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person(30000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974,3,14)
                },
                new Person(40000M)
                {
                    FirstName = "Bob",
                    LastName = "Jones",
                    DateOfBirth = new DateTime(1969,11,23)
                },
                new Person(20000M)
                {
                    FirstName = "Charlie" ,
                    LastName = "Cox",
                    DateOfBirth = new DateTime(1984,5,4),
                    Children = new HashSet<Person>
                    {
                        new Person(0M)
                        {
                            FirstName = "Sally",
                            LastName = "Cox",
                            DateOfBirth = new DateTime(2000,7,12)
                        }
                    }
                }
            };
            var xs = new XmlSerializer(typeof(List<Person>));
            string path = Combine(CurrentDirectory, "people.xml");
            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream,people);
            }
            WriteLine("Written {0:N0} bytes of XML to {1}",
                arg0: new FileInfo(path).Length,
                arg1: path);
            
            WriteLine();
            
            WriteLine(File.ReadAllText(path));
            
            //反序列化XML文件
            using (FileStream xmlLoad = File.Open(path,FileMode.Open))
            {
                var loadedPeople = (List<Person>) xs.Deserialize(xmlLoad);

                foreach (var  item in loadedPeople)
                {
                    WriteLine("{0} has {1} children.",item.LastName,item.Children.Count);
                }
            }
            
            //用Json序列化格式
            string jsonPath = Combine(CurrentDirectory, "people.json");
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                var jss = new Newtonsoft.Json.JsonSerializer();
                jss.Serialize(jsonStream,people);
            }
            
            WriteLine();
            WriteLine("Written {0:N0} bytes of JSON to : {1}",
                arg0: new FileInfo(jsonPath).Length,
                arg1: jsonPath);
            
            WriteLine(File.ReadAllText(jsonPath));
            
            //反序列化Json文件，然后输出人员的姓名以及子女数目
            using (FileStream jsonLoad = File.Open(jsonPath,FileMode.Open))
            {
                var loadedPeople = (List<Person>) await NuJson.DeserializeAsync(
                    utf8Json: jsonLoad,
                    returnType: typeof(List<Person>));

                foreach (var item in loadedPeople)
                {
                    WriteLine("{0} has {1} children.",item.LastName,item.Children?.Count);
                }
            }
        }
    }
}