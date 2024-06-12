using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using ProjAndreVeiculosSummary.BankAPI.Services;

namespace ProjAndreVeiculosSummary.BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankService _bankService;

        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public ActionResult<List<Bank>> GetAll()
        {
            return _bankService.GetAll();
        }

        [HttpPost]
        public ActionResult<Bank> Post(Bank bank)
        {
            _bankService.Create(bank);
            return bank;
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Bank> GetById(string id)
        {
            return _bankService.Get(id);
        }
    }
}
