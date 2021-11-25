using System;
using System.Collections.Generic;

namespace Packet.Shared
{
    //使用默认字面量设置字段
    public class ThingOfDefault
    {
        public int Population;
        public DateTime When;
        public string Name;
        public List<Person> People;

        public ThingOfDefault()
        {
            /*Population = default(int);
            When = default(DateTime);
            Name = default(string);
            People = default(List<Person>);*/
            
            //简化
            Population = default;
            When = default;
            Name = default;
            People = default;
        }
    }
}