using System;
using System.Collections.Generic;

namespace GiftExchange.Library
{
    public class DrawingService : IDrawingService
    {
        public IList<Person> Draw(IList<Person> participants)
        {
            var assignments = new List<Person>();
            var availableNames = new List<Person>(participants);

            foreach (var participant in participants)
            {
                var assignment = participant;
                var attempts = 0;

                while (assignment.Name.Equals(participant.Name) || attempts < 5)
                {
                    var rand = new Random();
                    assignment = availableNames[rand.Next(availableNames.Count)];
                    attempts++;
                }

                //if(attempts == 5)

                participant.PersonDrawn = assignment;
                assignments.Add(assignment);
                availableNames.Remove(assignment);
            }

            return assignments;
        }


    }
}
