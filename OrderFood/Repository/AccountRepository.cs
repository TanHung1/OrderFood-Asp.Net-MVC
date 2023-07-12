using OrderFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderFood.Areas.Identity.Data;
using OrderFood.Data;

namespace OrderFood.Repository
{
    public interface IAccountRepository
    {
        public List<AccountUser> GetAll();
        public bool UpdateAccount(AccountUser accountUser);

        public AccountUser findbyId(string id);

    }
    public class AccountRepository : IAccountRepository
        {
        private SignInManager<AccountUser> _signInManager;
        private readonly OrderFoodContext _orderFoodContext;

        public AccountRepository(SignInManager<AccountUser> signInManager, OrderFoodContext orderFoodContext)
        {
            _signInManager = signInManager;
            _orderFoodContext = orderFoodContext;
        }

        public List<AccountUser> GetAll()
        {
            return _orderFoodContext.Users.ToList();
        }

        public bool UpdateAccount(AccountUser accountUser)
        {
            AccountUser account = _orderFoodContext.Users.FirstOrDefault(x => x.Id == accountUser.Id);
            if (account != null)
            {
                account.Email = accountUser.Email;
                account.FirstName = accountUser.FirstName;
                account.LastName = accountUser.LastName;
                account.Address = accountUser.Address;
                account.PhoneNumber = accountUser.PhoneNumber;
                _orderFoodContext.SaveChanges();
                return true;
            }
            return false;
        }

        public AccountUser findbyId(string id)
        {
           AccountUser account = _orderFoodContext.Users.FirstOrDefault(x=> x.Id ==  id);
            return account;
        }
    }

}
