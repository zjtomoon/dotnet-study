using System;
namespace WorkingWithReflecttion
{
    //创建自定义特性
    /*
     * 定义一个特性类，可以用两个特性装饰类或方法，从而存储编码器的名称和代码最后修改的日期
     */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple = true)]
    public class CoderAttribute :Attribute
    {
        public string Coder { get; set; }
        public DateTime LastModified { get; set; }

        public CoderAttribute(string coder, string lastModified)
        {
            Coder = coder;
            LastModified = DateTime.Parse(lastModified);
        }
    }
}