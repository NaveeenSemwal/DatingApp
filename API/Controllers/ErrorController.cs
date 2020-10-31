using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly DataContext context;

        public ErrorController(DataContext context)
        {
            this.context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret-value";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var user = context.Users.Find(-1);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("server-error")]
        public ActionResult<AppUser> GetServerError()
        {
            var user = context.Users.Find(-1);

            var userToReturn = user.ToString();

            return Ok(userToReturn);
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is a Bad request.");
        }
    }
}
