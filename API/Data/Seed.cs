using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        private readonly UserManager<AppUser> _userManager;

        public Seed(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task SeedUsers(DataContext context)
        {
            if (await context.AppUsers.AnyAsync())
                return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var user in users)
            {
                // Store user data in AspNetUsers database table

                user.Email = user.UserName;

                var result = await _userManager.CreateAsync(user, "Dotvik@987");

                if (result.Succeeded)
                {
                }
            }
        }
    }
}
