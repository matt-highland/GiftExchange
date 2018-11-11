using System.Collections.Generic;

namespace GiftExchange.Library
{
    public interface IParticipantImporter
    {
        IList<Person> Read(string path);
    }
}