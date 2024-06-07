using Microsoft.AspNetCore.Mvc;
using PersonalAccounts2._0.DataAccess.Models;
using PersonalAccounts2._0.DTO;
using PersonalAccounts2._0.Service.Interfaces;

namespace PersonalAccounts2._0.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountDTO>>> GetAccounts()
        {
            try
            {
                var accounts = await _service.GetAllWithoutDetailsAsync();
                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<AccountDTO>> GetAccountById(int id)
        {
            try
            {
                var account = await _service.GetByIdAsync(id);

                return account == null
                ? NotFound()
                : Ok(account);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpGet("details")]
        public async Task<ActionResult<List<AccountWithResidentsDTO>>> GetAccountDetails()
        {
            try
            {
                var accounts = await _service.GetAllWithDetailsAsync();

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpGet("GetAccountsWithResidents")]
        public async Task<ActionResult<List<AccountDTO>>> GetAccountsWithResidents()
        {
            try
            {
                var accounts = await _service.GetAllWithResidentsAsync();

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpGet("searchname")]
        public async Task<ActionResult<List<AccountDTO>>> SearchResidentName(string residentName)
        {
            try
            {
                var accounts = await _service.GetAllByResidentNameAsync(residentName);

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpGet("searchaddress")]
        public async Task<ActionResult<List<AccountDTO>>> SearchAddress(string address)
        {
            try
            {
                var accounts = await _service.GetAllByAddressAsync(address);

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpGet("searchdate")]
        public async Task<ActionResult<List<AccountDTO>>> SearchDate(string date)
        {
            try
            {
                var accounts = await _service.GetAllByDateAsync(date);

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AccountModel model)
        {
            try
            {
                return await _service.AddAsync(model) ? Ok()
                : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<AccountDTO>> Put(int Id, AccountModel model)
        {
            try
            {
                var accountToUpdate = await _service.UpdateAsync(Id, model);

                if (accountToUpdate != null)
                {
                    return accountToUpdate;
                }
                else
                {
                    return NotFound($"Can't find account with Id {Id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was a database failure: {ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                return await _service.DeleteAsync(Id) ? Ok()
                : NotFound($"Can't find account with Id {Id}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was a database failure: {ex.Message}");
            }
        }
    }
}

