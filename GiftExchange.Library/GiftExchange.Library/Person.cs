namespace GiftExchange.Library
{
    public class Person
    {
        public Person(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public Person PersonDrawn { get; set; }
    }
}
