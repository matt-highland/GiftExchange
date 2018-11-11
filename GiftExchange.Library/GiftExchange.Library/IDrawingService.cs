using System.Collections.Generic;

namespace GiftExchange.Library
{
    public interface IDrawingService
    {
        IList<Person> Draw(IList<Person> participants);
    }
}