using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeyIdeasTest.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeyIdeasTest.Controllers
{
    [Authorize(Roles = UserRolesConstants.User)]
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
