using EasyBilling.Models.Pocos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBilling.Data
{
    public class DbInitializer : IDisposable
    {
        private static DbInitializer _dbInit;

        private readonly BillingDbContext _dbContext;
        private readonly UserManager<IdentityAccount> _userMgr;
        private readonly RoleManager<IdentityRole> _roleMgr;

        private DbInitializer(IHost host)
        {
            var scope = host.Services.CreateScope();
            var sp = scope.ServiceProvider;
            
            _userMgr = sp.GetRequiredService<UserManager<IdentityAccount>>();
            _roleMgr = sp.GetRequiredService<RoleManager<IdentityRole>>();
            _dbContext = sp.GetRequiredService<BillingDbContext>();
        }

        /// <summary>
        /// Получение единственного экземпляра
        /// </summary>
        /// <param name="host"></param>
        /// <returns>Возвращает объект класса</returns>
        public static DbInitializer GetInstance(IHost host) =>
            _dbInit = (_dbInit == null) ? new DbInitializer(host) : _dbInit;

        public void Initialize()
        {
            RolesInitializeAsync().Wait();
            AccessRightsInitializeAsync().Wait();
            UsersInitializeAsync().Wait();

            //Освобождаем ресурсы после использования сервисов
            _dbContext.Dispose();
            _userMgr.Dispose();
            _roleMgr.Dispose();
        }
        /// <summary>
        /// Инициализация пользователей
        /// </summary>
        /// <returns></returns>
        private async Task UsersInitializeAsync()
        {
            if (_userMgr.Users.Count() < 0)
            {
                var admin = new IdentityAccount()
                {
                    UserName = "admin",
                    Email = "admin@localhost",
                    PhoneNumber = "099-999-99-99",
                    IsEnabled = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    Profile = new Profile()
                    {
                        FirstName = "Администратор",
                        SecondName = "Биллинга",
                        Address = "Пушкина 9-15",
                        DateOfCreation = DateTime.Now
                    }
                };
                var result = await _userMgr.CreateAsync(admin, @"AQeT.5*gehWqeAh");
                if (result.Succeeded)
                {
                    var adminRole = Role.admin.ToString();
                    await _userMgr.AddToRoleAsync(admin, adminRole);
                }
            }
        }
        /// <summary>
        /// Инициализация ролей
        /// </summary>
        /// <returns></returns>
        private async Task RolesInitializeAsync()
        {
            if (_roleMgr.Roles.Count() == 0)
            {
                var roles = RoleHelper.GetRoles();
                foreach (var item in roles)
                {
                    await _roleMgr.CreateAsync(item);
                }
            }
        }
        /// <summary>
        /// Инициализация прав доступа
        /// </summary>
        /// <returns></returns>
        private async Task AccessRightsInitializeAsync()
        {
            if (_dbContext.AccessRights.Count() == 0)
            {
                const string cassaCtrl = "Cassa";
                const string usersCtrl = "Users";
                const string clientCtrl = "Client";
                const string deviceCtrl = "Device";
                const string accessRightsCtrl = "AccessRights";
                const string tariffCtrl = "Tariff";
                const string apiKeyCtrl = "APIKey";
                const string eventCtrl = "Event";
                const string financialOperationsCtrl = "FinancialOperations";
                #region admin
                var adminRole = await _roleMgr.FindByNameAsync(
                    Role.admin.ToString());
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = usersCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = clientCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = accessRightsCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = tariffCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = apiKeyCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = eventCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = financialOperationsCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = deviceCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = clientCtrl,
                    IsAvailable = true,
                    Role = adminRole
                });
                #endregion
                #region operator
                var operatorRole = await _roleMgr.FindByNameAsync(
                    Role.@operator.ToString());
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = usersCtrl,
                    IsAvailable = true,
                    Role = operatorRole
                });
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = clientCtrl,
                    IsAvailable = true,
                    Role = operatorRole
                });
                #endregion
                #region casher
                var casherRole = await _roleMgr.FindByNameAsync(
                    Role.casher.ToString());
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = cassaCtrl,
                    IsAvailable = true,
                    Role = casherRole
                });
                #endregion
                #region client
                var clientRole = await _roleMgr.FindByNameAsync(
                    Role.casher.ToString());
                _dbContext.AccessRights.Add(new AccessRight()
                {
                    ControllerName = clientCtrl,
                    IsAvailable = true,
                    Role = clientRole
                });
                #endregion

                await _dbContext.SaveChangesAsync();
            }
        }
        public async void Dispose()
        {
            await _dbContext.DisposeAsync();
            await Task.Run(() =>
            {
                _roleMgr.Dispose();
                _userMgr.Dispose();
            });
        }

        /// <summary>
        ///  Инициалищация базы данных абонентов
        /// </summary>
        /// <returns></returns>
        //private async Task ClientsInitializeAsync()
        //{

        //}
        ///// <summary>
        /////  Инициалищация тарифов
        ///// </summary>
        ///// <returns></returns>
        //private async Task TariffsInitializeAsync()
        //{

        //}
    }
}