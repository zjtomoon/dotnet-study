using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;

namespace WorkingWithStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkWithText();
            WorkWithXml();
            WorkWithCompression();
        }
        
        static string[] callsigns = new string[]
        {
            "Husker" , "Starbuck" , "Apollo" , "Boomer",
            "Bulldog", "Athena" , "Helo" , "Racetrack"
        };

        //写入文本流
        static void WorkWithText()
        {
            //定义写入的文件
            string textFile = Combine(CurrentDirectory, "streams.txt");
            //创建一个文本文件并返回一个帮助写入器
            StreamWriter text = File.CreateText(textFile);
            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close();
            
            WriteLine("{0} contains {1:N0} bytes",
                arg0: textFile,
                arg1: new FileInfo(textFile).Length);
            WriteLine(File.ReadAllText(textFile));
        }

        //写入xml流
        static void WorkWithXml()
        {
            FileStream xmlFileStream = null;
            XmlWriter xml = null;

            try
            {
                string xmlFile = Combine(CurrentDirectory, "streams.xml");
                xmlFileStream = File.Create(xmlFile);
                //使得xml自动缩进
                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings() {Indent = true});
                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");
                foreach (string item in callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                xml.WriteEndElement();
                xml.Close();
                xmlFileStream.Close();

                WriteLine("{0} contains {1:N0} bytes.",
                    arg0: xmlFile,
                    arg1: new FileInfo(xmlFile).Length);
                WriteLine(File.ReadAllText(xmlFile));
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }

                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The file stream's unmanaged resources have been disposed");
                }
            }
        }

        //压缩流
        static void WorkWithCompression()
        {
            //压缩xml输出
            string gzipFilePath = Combine(CurrentDirectory, "streams.gzip");
            FileStream gzipFile = File.Create(gzipFilePath);
            using (GZipStream compressor = new GZipStream(gzipFile,CompressionMode.Compress))
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");

                    foreach (string item in callsigns)
                    {
                        xmlGzip.WriteElementString("callsign",item);
                    }
                }
            }
            WriteLine("{0} contains {1:N0} bytes.",gzipFilePath,new FileInfo(gzipFilePath).Length);
            WriteLine($"The compressed contents:");
            WriteLine(File.ReadAllText(gzipFilePath));
            
            //读取压缩文件
            WriteLine("Reading the compressed contents:");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);
            using (GZipStream decompressor = new GZipStream(gzipFile,CompressionMode.Decompress))
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                        {
                            reader.Read();
                            WriteLine($"{reader.Value}");
                        }
                    }
                } 
            }
        }
    }
}