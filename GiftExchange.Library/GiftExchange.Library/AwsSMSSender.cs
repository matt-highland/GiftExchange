using System;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace GiftExchange.Library
{
    public class AwsSMSSender : ISMSSender
    {
        public void Send(string phone, string message)
        {
            AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.USEast1);
            PublishRequest pubRequest = new PublishRequest
            {
                Message = message,
                PhoneNumber = phone,
            };
            // add optional MessageAttributes, for example:
            //   pubRequest.MessageAttributes.Add("AWS.SNS.SMS.SenderID", new MessageAttributeValue
            //      { StringValue = "SenderId", DataType = "String" });
            PublishResponse pubResponse = snsClient.Publish(pubRequest);
        }
    }
}
