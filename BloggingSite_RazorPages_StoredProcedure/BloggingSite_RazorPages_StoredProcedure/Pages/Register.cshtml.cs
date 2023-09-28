using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingSite_RazorPages_StoredProcedure.DataAccess;
using BloggingSite_RazorPages_StoredProcedure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BloggingSite_RazorPages_StoredProcedure.Pages
{
    public class RegisterModel : PageModel
    {
        RegisterDA registerDA = new RegisterDA();

        public void OnGet()
        {

        }

        public IActionResult OnPostRegister(Register register)
        {

            registerDA.AddRegister(register);
            return Page();
        }

        [BindProperty]
        public Register register { get; set; }

        
    }
}
