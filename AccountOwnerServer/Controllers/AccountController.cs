
using Contract;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    /// <summary>
    /// Class <c>Account Controller</c> Class used for CRUD operations on Accounts Table
    /// </summary>
    [Route("api/account")]        
    [ApiController]

  
    
    public class AccountController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;
       
        public AccountController(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        /// <summary>
        /// Delete all accounts based on the owners ID
        /// </summary>
        /// <param name="id">id of the owner</param>
        /// <returns> <c>IActionResult</c> Returns the status code </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteAccountsByOwnerId(Guid id) 
        {
            var accountsToDelete = _repository.Account.AccountsByOwner(id);
            if (accountsToDelete is null)
            {
                return NotFound("no accounts found for this owner or the id is not valid");
            }
            else
            {
                _repository.Account.DeleteAllAccounts(accountsToDelete);
                _repository.Save();

                return NoContent();
            }
           
        }


    }
}

