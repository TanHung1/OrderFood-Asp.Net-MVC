using Microsoft.AspNetCore.Mvc;
using OrderFood.Areas.Identity.Data;
using OrderFood.Repository;

namespace OrderFood.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Index()
        {
            var accounts = _accountRepository.GetAll();
            return View(accounts);
        }
        public IActionResult EditAccount(string id)
        {
            var account = _accountRepository.findbyId(id);
            return View(account);
        }
        [HttpPost]
        public IActionResult UpdateAccount(AccountUser accountUser) 
        {
            _accountRepository.UpdateAccount(accountUser);
            return RedirectToAction("Index");
        }
    }
}
