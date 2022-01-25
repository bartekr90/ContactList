using System.Drawing;
using System.IO;

namespace ContactList
{
    public class Contact
    {
        public int _Id { get; set; }
        public string _Photo { get; set; }
        public Image _Picture
        {
            get
            {
                if (!string.IsNullOrEmpty(_Photo))
                {
                    if (File.Exists(_Photo))
                        return Image.FromFile(_Photo);
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
