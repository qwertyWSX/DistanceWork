using DistanceWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistanceWork.Controllers
{
    [Route("api/Jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        private readonly DistanceWorkContext _context;

        public JobsController(DistanceWorkContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult<Job>> PostAccount(Job job)
        { 
            _context.Job.Add(job);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Job>> CancelJob(int id, Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetTodoItems()
        {
            return await _context.Job.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<List<Job>> GetJob(int id)
        {
            var job = await _context.Job.Where(x => x.Worker == id || x.Master == id).ToListAsync();
            return job;
        }

        [HttpGet("CurrentJob/{id}")]
        public async Task<List<Job>> GetCurrentJob(int id)
        {
           

            var job = await _context.Job.Where(x => x.Worker == id && x.Status == "Выполнение").ToListAsync();          
            return job;
        }

        [HttpGet("Assigened/{id}")]
        public async Task<List<Job>> GetAssigenedJob(int id)
        {


            var job = await _context.Job.Where(x => x.Master == id && x.Status == "Выполнение").ToListAsync();
            return job;
        }



        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.Id == id);
        }

    }
}
