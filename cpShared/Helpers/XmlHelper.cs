using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace cpShared.Helpers
{
    public class XmlHelper
    {
        public static T DeserializeXMLFileToObject<T>(Stream xmlStream, XmlRootAttribute root)
        {
            xmlStream.Seek(0, SeekOrigin.Begin);
            T returnObject = default;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T), root);
                returnObject = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception)
            {
            }
            return returnObject;
        }
    }
}
