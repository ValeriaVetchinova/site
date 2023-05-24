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

            // �������� �� ����� email � ������
            var form = HttpContext.Request.Form;
            // ���� email �/��� ������ �� �����������, �������� ��������� ��� ������ 400
            if (!form.ContainsKey("login") || !form.ContainsKey("password"))
                return BadRequest("Email �/��� ������ �� �����������");

            string login = form["login"];
            string password = form["password"];
            
            var db = new MydbContext();
            User? user = db.Users.FirstOrDefault(p => p.Login == login && p.Password == password);
            // ���� ������������ �� ������, ���������� ��������� ��� 401
            if (user is null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
            // ������� ������ ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            // ��������� ������������������ ����
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            
            return Redirect("/");
        
        }
    }
}
