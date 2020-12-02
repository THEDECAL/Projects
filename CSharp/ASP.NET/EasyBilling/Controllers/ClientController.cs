using EasyBilling.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace EasyBilling.Controllers
{
    [Authorize]
    [CheckAccessRights]
    [NoShowToMenu]
    [DisplayName("Клиент")]
    public class ClientController : CustomController
    {
    }
}
