using System.Collections.Generic;

namespace GiftExchange.Library
{
    public class ExchangeLogger : IExchangeLogger
    {
        public void Write(IList<Person> participants, string path)
        {
            using (var file = new System.IO.StreamWriter(path))
            {
                foreach (var participant in participants)
                {
                    file.WriteLine($"{participant.Name} -> {participant.PersonDrawn.Name}");
                }
            }
        }
    }
}
