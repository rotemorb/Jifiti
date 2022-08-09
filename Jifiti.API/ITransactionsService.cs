namespace Jifiti.API
{
    public interface ITransactionsService
    {
        Task<string> GetPersons();
        Task<string> GetCards(string cardNo);
        Task<string> GetTransactions(string appId);
    }
}
