using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core.Model;

namespace Core
{
    public static class SerializePagesList
    {
        public static List<TextPage> Serialize(List<TextPage> textPages)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TextPage>));
            StreamWriter streamWriter = new StreamWriter("aaa.xml");
            using (streamWriter)
            {
                serializer.Serialize(streamWriter, textPages);
            }

            return textPages;
        }
    }
}