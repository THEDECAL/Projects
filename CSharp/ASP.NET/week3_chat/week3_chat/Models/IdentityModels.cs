using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace week3_chat.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public bool IsBlockedInChat { get; set; } = false;
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(this));

            var adminsRole = new IdentityRole { Name = "admins" };
            var usersRole = new IdentityRole { Name = "users" };

            roleManager.Create(adminsRole);
            roleManager.Create(usersRole);

            var admin = new ApplicationUser { Email = "admin@localhost.com", UserName = "admin@localhost.com" };
            var adminPassword = "adminadmin";

            var result = userManager.Create(admin, adminPassword);

            if (result.Succeeded)
                userManager.AddToRole(admin.Id, adminsRole.Name);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}