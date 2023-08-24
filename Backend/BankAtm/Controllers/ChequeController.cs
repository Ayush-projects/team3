using BankAtm.Entities;
using BankAtm.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BankAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Roles = "admin")]
    public class ChequeController : ControllerBase
    {
        IChequeService _chequeService;
        public ChequeController(IChequeService chequeService)
        {
            _chequeService = chequeService;
        }
        [HttpGet, Route("GetChequeDetailsByAccNo")]
        public IActionResult GetChequeDetails(long AccNum)
        {
            try
            {
                List<Cheque> CheueList = _chequeService.GetChequesByAccNum(AccNum);
                return StatusCode(200,CheueList);

            }catch(Exception ex) { return StatusCode(201, new JsonResult(ex.Message)); }
        }
    }
}
