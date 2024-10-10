using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventorySerivce.Data;
using InventorySerivce.Models;
using InventorySerivce.Services.EntityServices;

namespace InventorySerivce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly InventorySerivceContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UsersController(/*InventorySerivceContext context*/ IUserRepository userRepository, IUserService userService)
        {
            //_context = context;
            _userRepository = userRepository;
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}/balance")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserBalance(long id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Balance);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _userService.AddUser(user);
            return Created("/api/users/" + user.Id, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            /*
            User? user = _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            _userRepository.Delete(id);*/
            return NoContent();
        }

        private bool UserExists(long id)
        {
            /*User? user = _userRepository.GetById(id);
            if (user == null)
            {
                return false;
            }*/
            return true;
        }
    }
}
