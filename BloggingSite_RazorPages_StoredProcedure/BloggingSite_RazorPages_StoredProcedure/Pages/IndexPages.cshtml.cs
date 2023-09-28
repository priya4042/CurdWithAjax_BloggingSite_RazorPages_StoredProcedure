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
    
    public class IndexPagesModel : PageModel
    {
        PostDA postDA = new PostDA();

        public IActionResult OnGet()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            if (id != 0)
            {
                postList = postDA.GetAllPost();
                return Page();
            }
            return RedirectToPage("/Login");
        }

        public IActionResult OnGetIndexPages(int? id)
        {
            return Page();
        }

        [BindProperty]
        public IEnumerable<Post> postList { get; set; }
    }
}
