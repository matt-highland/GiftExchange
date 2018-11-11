using System.Collections.Generic;

namespace GiftExchange.Library
{
    public interface IExchangeLogger
    {
        void Write(IList<Person> participants, string path);
    }
}