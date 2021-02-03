using JdMvcHouTai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace JdMvcHouTai.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserBackgroundPage page)
        {
            var user = _context.UserBackgrounds.FirstOrDefault(m => m.UserName == page.Emile && m.PassWord == page.PassWord);
            return RedirectToAction("Home", "Background");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserBackgroundPage page)
        {
            UserBackground user = new UserBackground();
            user.UserName = page.Username;
            user.PassWord = page.PassWord;
            if (user != null)
            {
                _context.UserBackgrounds.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult NameIsExists(string Username)
        {

            var yhm = _context.Users.SingleOrDefault(m => m.LoginName == Username);
            if (yhm != null)
            {
                return Json("用户名重复");
            }

            return Json(true);
        }

    }
}
