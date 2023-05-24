using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VetchinovaTeplyakova.Models;

namespace VetchinovaTeplyakova.Pages
{
    public class Index1Model : BasePagesModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(string? returnUrl)
        {

            // получаем из формы email и пароль
            var form = HttpContext.Request.Form;
            // если email и/или пароль не установлены, посылаем статусный код ошибки 400
            if (!form.ContainsKey("login") || !form.ContainsKey("password"))
                return BadRequest("Email и/или пароль не установлены");

            string login = form["login"];
            string password = form["password"];
            
            var db = new MydbContext();
            User? user = db.Users.FirstOrDefault(p => p.Login == login && p.Password == password);
            // если пользователь не найден, отправляем статусный код 401
            if (user is null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
            // создаем объект ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            
            return Redirect("/");
        
        }
    }
}
