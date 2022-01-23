using System.IO;
using System.Xml.Serialization;

namespace ContactList
{
    public class FileHelper<T> where T : new()
    {
        private string _filepath = "";
        public FileHelper(string path)
        {
            _filepath = path;
        }
        public void Serialization(T contactList)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var streamWriter = new StreamWriter(_filepath))
            {
                serializer.Serialize(streamWriter, contactList);
                streamWriter.Close();
            }
        }
        public T Deserialization()
        {
            if (!File.Exists(_filepath))
                return new T();

            var serializer = new XmlSerializer(typeof(T));

            using (var streamReader = new StreamReader(_filepath))
            {
                var list = (T)serializer.Deserialize(streamReader);
                streamReader.Close();
                return list;
            }
        }
    }
}
