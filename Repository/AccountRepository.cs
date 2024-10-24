using Contract;
using Entities;
using Entities.Models;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Account> AccountsByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
        }

        public void DeleteAllAccounts(IEnumerable<Account> accounts)
        {
            foreach(Account account in accounts)
            {
                Delete(account);
            }
        }
    }
}