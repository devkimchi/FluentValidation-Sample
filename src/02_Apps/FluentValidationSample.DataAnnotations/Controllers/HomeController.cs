using System.Threading.Tasks;
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
            var vm = new RegisterViewModel();
            return View(vm);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Register(RegisterViewModel form)
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