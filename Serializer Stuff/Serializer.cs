using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Business.Layer
{
    public class Serializer
    {
        public static string InputFile { get; set; }
        public static string OutputFile { get; set; }
        static System.IO.StreamReader reader;
        static System.IO.StreamWriter writer;

        public static List<Resturant> Deserialize()
        {
            Resturant r = new Resturant();
            
            reader = new System.IO.StreamReader(InputFile);
            MyList<Resturant> my = new MyList<Resturant>();
            XmlSerializer x = new XmlSerializer(my.GetType());
            List<Resturant> list = (List<Resturant>)x.Deserialize(reader);
            reader.Close();
            return list;
        }

        public static void Serialize(List<Resturant> list)
        {
            writer = new System.IO.StreamWriter(OutputFile);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(writer, list);
            writer.Close();
        }
    }
}
