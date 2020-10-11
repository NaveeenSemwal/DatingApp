using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private const string Id = "{id}";
        private readonly DataContext _dbContext;
        public UsersController(DataContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAll()
        {
           return await _dbContext.AppUsers.ToListAsync();
        }

        [HttpGet(Id)]
        public async Task<ActionResult<AppUser>> Get(int id) 
        { 
           return await  _dbContext.AppUsers.FindAsync(id);
        }

    }
}
