using System.Collections.Generic;

namespace GiftExchange.Library
{
    public class ParticipantImporter : IParticipantImporter
    {
        public IList<Person> Read(string path)
        {
            string record;
            var participants = new List<Person>();
            var file = new System.IO.StreamReader(path);
            while ((record = file.ReadLine()) != null)
            {
                var lineArray = record.Split(',');
                participants.Add(new Person(lineArray[0], lineArray[1]));
            }

            file.Close();

            return participants;
        }
    }
}
