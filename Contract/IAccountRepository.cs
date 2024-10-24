using Entities.Models;

namespace Contract
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);

        void DeleteAllAccounts(IEnumerable<Account> accounts);
    }
}
