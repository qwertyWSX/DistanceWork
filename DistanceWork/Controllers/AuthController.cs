using DistanceWork.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistanceWork.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DistanceWorkContext _context;

        public AuthController(DistanceWorkContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {         
            foreach(var ac in _context.Accounts)
            {
                if (ac.Login == account.Login && ac.Password == account.Password)
                {
                     return ac;
                }                                            
            }           
            return NotFound();
        }    
    }
}
