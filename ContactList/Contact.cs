using System.Drawing;
using System.IO;

namespace ContactList
{
    public class Contact
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public Image Picture
        {
            get
            {
                if (!string.IsNullOrEmpty(Photo))
                {
                    if (File.Exists(Photo))
                        return Image.FromFile(Photo);
                }
                return null;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Comments { get; set; }
    }
}
