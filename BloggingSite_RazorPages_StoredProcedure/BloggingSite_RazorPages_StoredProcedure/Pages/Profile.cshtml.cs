using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingSite_RazorPages_StoredProcedure.DataAccess;
using BloggingSite_RazorPages_StoredProcedure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggingSite_RazorPages_StoredProcedure.Pages
{
   
    public class ProfileModel : PageModel
    {
        RegisterDA registerDA = new RegisterDA();

        
        public IActionResult OnGet()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            if (id != 0)
            {
                register = registerDA.GetRegData(id);
                return Page();
            }

            return RedirectToPage("/Login");

       }
        

        [BindProperty]
        public Register register { get; set; }
    }
}
