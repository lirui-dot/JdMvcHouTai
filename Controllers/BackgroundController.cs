using JdMvcHouTai.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JdMvcHouTai.Controllers
{
    public class BackgroundController : Controller
    {
        private readonly UserContext _context;


        public BackgroundController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Home(UserPage page)
        {
            var user = _context.Users.ToList();
            //查询用户名登录名名字
            if (page.SearchUserName != null && page.SearchLoginName != null && page.SearchName != null)
            {
                var userloginname = _context.Users.Where(m => m.UserName == page.SearchUserName && m.LoginName == page.SearchLoginName && m.Name == page.SearchName).ToList();
                ViewBag.body = userloginname;
                return View();
            }
            //查询用户名登录名
            if (page.SearchUserName != null && page.SearchLoginName != null)
            {
                var userlogin = _context.Users.Where(m => m.UserName == page.SearchUserName && m.LoginName == page.SearchLoginName).ToList();
                ViewBag.body = userlogin;
                return View();
            }
            //查询登录名名字
            if (page.SearchLoginName != null && page.SearchName != null)
            {
                var loginName = _context.Users.Where(m => m.Name == page.SearchName && m.LoginName == page.SearchLoginName).ToList();
                ViewBag.body = loginName;
                return View();
            }
            //查询用户名名字
            if (page.SearchLoginName != null && page.SearchName != null)
            {
                var loginName = _context.Users.Where(m => m.Name == page.SearchName && m.UserName == page.SearchUserName).ToList();
                ViewBag.body = loginName;
                return View();
            }
            //查询用户名
            if (page.SearchUserName != null)
            {
                var UserName = _context.Users.Where(m => m.UserName == page.SearchUserName).ToList();
                ViewBag.body = UserName;
                return View();
            }
            //查询登录名
            if (page.SearchLoginName != null)
            {
                var LoginName = _context.Users.Where(m => m.LoginName == page.SearchLoginName).ToList();
                ViewBag.body = LoginName;
                return View();
            }
            //查询名字
            if (page.SearchName != null)
            {
                var Name = _context.Users.Where(m => m.Name == page.SearchName).ToList();
                ViewBag.body = Name;
                return View();
            }
            ViewBag.body = user;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHome([FromBody] UserPage page)
        {
            //异步加载添加一个用户
            User user = new User();
            user.UserName = page.UserName;
            user.LoginName = page.LoginName;
            user.Name = page.Name;
            user.PassWord = page.PassWord;
            if (user != null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Json(user);
            }
            return View(page);
        }
        public IActionResult EditHome(int? id)
        {
            //异步编辑
            var user = _context.Users.Find(id);
            return Json(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditHome([FromBody] UserPage page)
        {
            //异步修改用户数据
            var user = _context.Users.Find(page.Id);
            user.UserName = page.UserName;
            user.LoginName = page.LoginName;
            user.Name = page.Name;
            user.PassWord = page.PassWord;
            if (user != null)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return Json(user);
            }
            return Json(page);
        }
        public async Task<IActionResult> DelectHome(int? id)
        {
            //删除一个用户
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home", "Background");
        }
        public IActionResult ModelAdministration(UserPage page)
        {
            var hobby = _context.Hobbies.ToList();
            ViewBag.Hobbies = hobby;
            //查询兴趣爱好
            if (page.SearchHobbyClassification != null)
            {
                var hobbies = _context.Hobbies.Where(m => m.HobbyClassification == page.SearchHobbyClassification).ToList();
                ViewBag.Hobbies = hobbies;
                return View();
            }
            return View();
        }
        public async Task<IActionResult> ModelDelect(int? id)
        {
            //删除一个兴趣爱好
            var hobby = _context.Hobbies.Find(id);
            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();
            return RedirectToAction("ModelAdministration", "Background");
        }
        [HttpPost]
        public async Task<IActionResult> ModelAdd([FromBody] string HobbyClassification)
        {
            //异步添加兴趣爱好

            Hobby hobby = new Hobby();
            hobby.HobbyClassification = HobbyClassification;
            if (hobby != null)
            {
                _context.Hobbies.Add(hobby);
                await _context.SaveChangesAsync();
                return Json(hobby);
            }
            return Json(HobbyClassification);
        }
        public IActionResult ModelEdit(int? id)
        {
            //异步读取数据
            var hobby = _context.Hobbies.Find(id);
            return Json(hobby);
        }
        [HttpPost]
        public async Task<IActionResult> ModelEdit([FromBody] UserPage page)
        {
            //异步修改兴趣爱好
            var hobby = _context.Hobbies.Find(page.Id);
            hobby.HobbyClassification = page.HobbyClassification;
            if (hobby != null)
            {
                _context.Update(hobby);
                await _context.SaveChangesAsync();
                return Json(hobby);
            }
            return Json(page);
        }
        public IActionResult Provinces()
        {
            //加载所有省份 
            // var province = _context.Provinces.ToList();
            // ViewBag.Province = province;
            /*  */
            return View();
        }
        [HttpPost]
        public IActionResult ProvincesLoading(int length, int start)
        {
            ProvinceView view = new ProvinceView();
            //加载所有省份
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //查询所有省份
            var province = _context.Provinces.ToList();

            //加载所有省份的数量
            view.recordsTotal = province.Count();
            if (searchValue != "")
            {
                province = _context.Provinces.Where(s => s.id.ToString().Contains(searchValue)
                               || s.name.Contains(searchValue)
                               || s.parentid.ToString().Contains(searchValue)).ToList();
            }

            //查询到的省份的数量
            view.recordsFiltered = province.Count();

            if (start.ToString() != "0")
            {
                province = province.Skip(start).Take(length).ToList();
            }
            else
            {
                province = province.Skip(start).Take(length).ToList();
            }

            view.data = province;


            return Json(view);
        }
        public async Task<IActionResult> ProvincesDelect(int? id)
        {
            //删除省份
            var province = _context.Provinces.Find(id);
            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();
            return RedirectToAction("Provinces", "Background");
        }
        [HttpPost]
        public async Task<IActionResult> ProvincesAdd([FromBody] string name)
        {
            //异步添加省份
            Province province = new Province();
            province.name = name;
            if (province != null)
            {
                _context.Provinces.Add(province);
                await _context.SaveChangesAsync();
                return Json(province);
            }
            return Json(name);
        }
        public IActionResult ProvincesEdit(int? id)
        {
            var province = _context.Provinces.Find(id);
            return Json(province);
        }
        [HttpPost]
        public async Task<IActionResult> ProvincesEdit([FromBody] UserPage page)
        {
            //异步省份城市
            var province = _context.Provinces.Find(page.Id);
            province.name = page.PrvoncesName;
            if (province != null)
            {
                _context.Update(province);
                await _context.SaveChangesAsync();
                return Json(province);
            }
            return Json(page);
        }
    }
}

