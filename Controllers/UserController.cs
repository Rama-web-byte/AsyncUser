using AsyncUser.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AsyncUser.Models;

namespace AsyncUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var result = await repo.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("id")]
        
        public async Task<ActionResult<User>> GetUserByid(int id)
        {
            try
            {
                var result = await repo.GetById(id);
                return Ok(result);
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                var result = await repo.AddUser(user);
                return CreatedAtAction(nameof(GetUserByid), new { id = result.Id }, result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(int id,User user)
        {
            try
            {
                 await repo.UpdateUser(id,user);
                return NoContent();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        


        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await repo.DeleteUser(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
