using PetroTech.Main.Infa.Core;
using PetroTech.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetroTech.Main.WebApi
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiControllerBase
    {
        private IUserService _userService;

        public RoleController(ILogService logService, IUserService userService) :
            base(logService)
        {
            this._userService = userService;
        }
    }
}
