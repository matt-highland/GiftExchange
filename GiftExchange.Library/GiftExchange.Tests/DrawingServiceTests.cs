using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GiftExchange.Library;
using NUnit.Framework;
using Shouldly;

namespace GiftExchange.Tests
{
    [TestFixture]
    public class DrawingServiceTests
    {
        [Test]
        public void Draw_matches_everybody_up()
        {
            // Arrange
            var service = new DrawingService();

            // Act
            var results = service.Draw(TestParticipants);

            // Assert
            results.All(r => r.PersonDrawn != null);
        }

        [Test]
        public void Draw_returns_the_same_number_of_participants_as_was_passed_in_args()
        {
            // Arrange
            var service = new DrawingService();

            // Act
            var results = service.Draw(TestParticipants);

            // Assert
            results.Count.ShouldBe(TestParticipants.Count);
        }

        [Test]
        public void Draw_doesnt_assign_anybody_to_themselves()
        {
            // Arrange
            var service = new DrawingService();

            // Act
            var results = service.Draw(TestParticipants);

            // Assert
            foreach (var result in results)
            {
                result.Name.ShouldNotBe(result.PersonDrawn.Name);
            }
        }

        [Test]
        public void Draw_doesnt_match_somebody_up_twice()
        {
            // Arrange
            var service = new DrawingService();

            // Act
            var results = service.Draw(TestParticipants);

            // Assert
            results.Select(r => r.PersonDrawn.Name).Distinct().Count().ShouldBe(TestParticipants.Count);

            foreach (var result in results)
            {
                Debug.WriteLine($"{result.Name} was assigned to {result.PersonDrawn.Name}");
            }
        }

        private IList<Person> TestParticipants => new List<Person>
        {
            new Person("matt", "3123123122"),
            new Person("Tiffany", "555-555-5555"),
            new Person("Trinity", "7778889999"),
            new Person("ben", "14567893214"),
            new Person("Kennedy", "9998884444"),
            new Person("anthony", "1112223333"),
        };
    }
}
