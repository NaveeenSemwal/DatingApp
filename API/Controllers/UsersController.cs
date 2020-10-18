using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private const string Id = "{id}";
        private readonly DataContext _dbContext;
        public UsersController(DataContext dbContext) => _dbContext = dbContext;

        // http://localhost:5000/api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAll()
        {
           return await _dbContext.AppUsers.ToListAsync();
        }

        // http://localhost:5000/api/users
        [HttpGet(Id)]
        public async Task<ActionResult<AppUser>> Get(int id) 
        { 
           return await  _dbContext.AppUsers.FindAsync(id);
        }

    }
}
