using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Helpers.Extensions
{

    public static class ObjectExtensions
    {
        public static string ToXmlString<T>(this T obj)
        {
            return serializeObject(obj);
        }

        private static string serializeObject<T>(T obj)
        {
            //if (!obj.GetType().IsSerializable) return "The object is not serializable.";
            var xs = new XmlSerializer(obj.GetType());
            var sw = new StringWriter();
            var w = new XmlTextWriter(sw) { Formatting = Formatting.Indented, Indentation = 3 };

            xs.Serialize(w, obj);
            w.Flush();
            w.Close();

            return sw.ToString();
        }

        private static T DeSerializeXML<T>(string s)
        {
            var xs = new XmlSerializer(typeof(T));
            var sr = new StringReader(s);

            var r = (T)xs.Deserialize(sr);

            return r;
        }

        public static T To_T_FromXmlString<T>(this string s)
        {
            return DeSerializeXML<T>(s);
        }
    }

}
