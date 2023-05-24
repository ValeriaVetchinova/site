using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using VetchinovaTeplyakova.Models;

namespace VetchinovaTeplyakova.Pages
{
    public class BasePagesModel : PageModel
    {
        public Staff? staff { get; set; }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Claim? claim = HttpContext.User.FindFirst(ClaimTypes.Name);
            if (claim !=null) 
            {
                string[] raw = Convert.ToString(claim)!.Split(" ");
                ViewData["Login"]=raw[1];
            }
            base.OnPageHandlerExecuting(context);  
        }
        
    }
}
