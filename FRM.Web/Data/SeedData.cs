using FRM.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRM.Web.Data
{
    public class SeedData
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public SeedData(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeDataAsync()
        {
            await CreateUsersAsync();
            CreateFamilies();
        }

        private IEnumerable<FamilyMember> GetFamilyMembers()
        {
            var familyMembers = new List<FamilyMember>();
            FamilyMember sara = new FamilyMember() { FirstName = "Sara", LastName = "McManus", Birthday = new DateTime(1985,08,02) };
            FamilyMember ella = new FamilyMember() { FirstName = "Ella", LastName = "McManus", Birthday = new DateTime(2014,11,13)};
            familyMembers.Add(sara);
            familyMembers.Add(ella);
            return familyMembers;
        }

        private void CreateFamilies()
        {

            if (!_context.Families.Any())
            {
                var family = new Family()
                {
                    Name = "McManus",
                    Username = "danmcmanus11",
                    FamilyMembers = GetFamilyMembers().ToList()
                };

                _context.Families.Add(family);
                _context.SaveChanges();
            }
        
        }

        private async Task CreateUsersAsync()
        {
            var user = await _userManager.FindByEmailAsync("danmcmanus11@outlook.com");
            if (user == null)
            {
                user = new ApplicationUser { UserName = "danmcmanus11", Email = "danmcmanus11@outlook.com" };
                await _userManager.CreateAsync(user, "#Rmm8voub");

                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("FamilyManager", "Allowed"));
            }

        }
    }
}
