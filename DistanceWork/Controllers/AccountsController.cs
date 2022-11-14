using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DistanceWork.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace DistanceWork.Controllers
{
    [Route("api/Accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly DistanceWorkContext _context;

        public AccountsController(DistanceWorkContext context, IHostingEnvironment environment)
        {
            _context = context;
            hostingEnvironment = environment;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetTodoItems()
        {
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        // GET: api/Accounts/getPhoto/5
        [HttpGet("getPhoto/{id}")]
        public async Task<ActionResult<Account>> GetPhoto(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account.filePath != null)
            {
                string filepath = account.filePath;
                string file_type = "application/jpg";
                string filename = account.Login + ".jpg";
                return PhysicalFile(filepath, file_type, filename);
            }
            else
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploads, "unknown.jpg");
                return PhysicalFile(filePath, "application/jpg", "unknown.jpg");
            }
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount( [FromForm] Account account)
        {         
            foreach(var ac in _context.Accounts)
            {
                if (ac.Login == account.Login)
                {
                    return Conflict();
                }
            }


           

            if (account.file != null)
            {
                string filename = account.Login + ".jpg";
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploads, filename);
                account.file.CopyTo(new FileStream(filePath, FileMode.Create));
                account.filePath = filePath;
            }    
           
            _context.Accounts.Add(account); 
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return account;
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
