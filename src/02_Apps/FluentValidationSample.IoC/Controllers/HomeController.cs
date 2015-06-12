using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FluentValidationSample.WebApp.Models;

namespace FluentValidationSample.WebApp.Controllers
{
    public partial class HomeController : Controller
    {
        // GET: Home
        public virtual async Task<ActionResult> Index()
        {
            return View();
        }

        public virtual async Task<ActionResult> Register()
        {
            var vm = new RegisterViewModel2();
            return View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Register(RegisterViewModel2 form)
        {
            var vm = form;
            if (ModelState.IsValid)
            {
                vm.Validated = true;
            }
            return View(vm);
        }
    }
}