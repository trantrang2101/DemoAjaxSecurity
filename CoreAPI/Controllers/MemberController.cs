using CoreAPI.DTO;
using CoreAPI.Responsitory.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemberController : Controller
    {
        private readonly IMemberResponsitory responsitory;

        public MemberController(IMemberResponsitory responsitory)
        {
            this.responsitory = responsitory;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginAccount)
        {
            string token = responsitory.Login(loginAccount);
            if(token == null)
            {
                return NotFound();
            }
            return Ok(token);
        }
        [HttpGet]
        [Authorize]
        public IActionResult List()
        {
            return Ok(responsitory.GetMembers());
        }
    }
}
