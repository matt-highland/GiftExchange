namespace GiftExchange.Library
{
    public interface ISMSSender
    {
        void Send(string phone, string message);
    }
}