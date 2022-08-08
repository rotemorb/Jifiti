namespace Jifiti.API
{
    public interface ITransactionsService
    {
        Task<string> GetPersons();
        Task<string> GetCards(string appId);
        Task<string> GetTransactions(string appId);
    }
}
