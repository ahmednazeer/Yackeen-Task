using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Yackeen.Models.Helpers
{
    public class RoleHelpers
    {
        public static async Task<string> createRole(string roleName, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExists(roleName)) {
                await roleManager.CreateAsync(new IdentityRole(roleName));
                return "Success";
            }
            else
            {
                return "Existed";
            }
                
            /*string id = User.Identity.GetUserId();
            await UserManager.AddToRoleAsync(id, "admin");*/
        }
    }
}