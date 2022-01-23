namespace ContactList
{
    public class Contact
    {
        public Contact()
        {
            _id = 0;
            _photo = "";
            _FirstName = "brak";
            _LastName = "brak";
            _PhoneNr = "brak";
            _Email = "brak";
            _Company = "brak";
            _Position = "brak";
            _Comments = "brak";
        }
        public enum TypeOfContact : byte
        {
            personal = 1,
            corpotate = 2
        }
        public int _id { get; set; }
        public string _photo { get; set; }
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public string _PhoneNr { get; set; }
        public string _Email { get; set; }
        // public TypeOfContact Type;
        public string _Company { get; set; }
        public string _Position { get; set; }
        public string _Comments { get; set; }
    }
}
