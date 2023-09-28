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
    public class ProfileEditModel : PageModel
    {
        [BindProperty]
        public Register register { get; set; }

        RegisterDA registerDA = new RegisterDA();


        public IActionResult OnGet(int? id)
        {
           register  = registerDA.GetRegData(id);

            return Page();
        }

        public IActionResult OnPost(Register register)
        {

            registerDA.UpdateRegister(register);
            return RedirectToPage("./Profile");
        }
    }
}
