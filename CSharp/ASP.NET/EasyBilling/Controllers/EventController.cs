using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using EasyBilling.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyBilling.Controllers
{
    [Authorize]
    [CheckAccessRights]
    [DisplayName("Журнал событий")]
    public class EventController : CustomController
    {
    }
}
