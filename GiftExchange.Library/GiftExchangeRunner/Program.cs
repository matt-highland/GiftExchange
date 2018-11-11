using System;
using GiftExchange.Library;

namespace GiftExchangeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];

            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Import file path required");
                return;
            }

            IParticipantImporter importer = new ParticipantImporter();
            IDrawingService drawingService = new DrawingService();
            ISMSSender textMessageSender = new AwsSMSSender();

            var participants = importer.Read(path);

            var assignments = drawingService.Draw(participants);

            foreach (var assignment in assignments)
            {
                var message = $"{assignment.Name}, welcome to the Highland Gift Exchange. You drew {assignment.PersonDrawn.Name}. $10 limit, white elephant gift.";
                textMessageSender.Send(assignment.Phone, message);
                
                Console.WriteLine($"Text sent to {assignment.Name}");
            }

            if (!string.IsNullOrEmpty(args[1]))
            {
                IExchangeLogger logger = new ExchangeLogger();
                logger.Write(assignments, args[1]);
            }
        }
    }
}
