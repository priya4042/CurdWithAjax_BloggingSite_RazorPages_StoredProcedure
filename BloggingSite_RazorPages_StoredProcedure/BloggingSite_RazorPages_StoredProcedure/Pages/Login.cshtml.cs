using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BloggingSite_RazorPages_StoredProcedure.DataAccess;
using BloggingSite_RazorPages_StoredProcedure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggingSite_RazorPages_StoredProcedure.Pages
{


    public class LoginModel : PageModel
    {
       // private readonly HttpContextAccessor _httpContextAccessor;

        RegisterDA registerDA = new RegisterDA();
        public void OnGet()
        {

        }
        [BindProperty]
        public Register register { get; set; }

        public IActionResult OnPostLogin(Register register)
        {



            Register result = registerDA.Login(register);
            if (result.Id > 0)
            {
                HttpContext.Session.SetInt32("ID", result.Id);

                return RedirectToPage("Profile");

            }
            else
            {
                return RedirectToPage("Login");
            }
        }


        public IActionResult OnGetLogout()
        {
            var user = User;
            var identity = user.Identity as ClaimsIdentity;
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            return RedirectToPage("/Login");
        }
    }
}
