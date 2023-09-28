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
    public class BlogModel : PageModel
    {
        PostDA postDA = new PostDA();

        public IActionResult OnGet()
        {
            //Getting all user details
            postList = postDA.GetAllPost();
            return Page();
        }

        //Binding Post Class
        [BindProperty]
        public IEnumerable<Post> postList { get; set; }
        
    }
}
