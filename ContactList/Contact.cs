using System.Drawing;
using System.IO;

namespace ContactList
{
    public class Contact
    {
        public int _id { get; set; }
        public string _photo { get; set; }
        public Image Picture
        {
            get
            {
                if (!string.IsNullOrEmpty(_photo))
                {
                    if (File.Exists(_photo))
                        return Image.FromFile(_photo);
                }
                return null;
            }
        }
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public string _PhoneNr { get; set; }
        public string _Email { get; set; }
        public string _Type { get; set; }
        public string _Company { get; set; }
        public string _Position { get; set; }
        public string _Comments { get; set; }
    }
}
