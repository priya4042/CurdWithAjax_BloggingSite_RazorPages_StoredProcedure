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
    public class PostEditModel : PageModel
    {
        PostDA postDA = new PostDA();

        [BindProperty]
        public Post post { get; set; }

        public IActionResult OnGet(int? id)
        {
            post = postDA.GetPostData(id);

            return Page();
        }

        public IActionResult OnPost(Post post)
        {
           
            postDA.UpdatePost(post);
            return RedirectToPage("./IndexPages");
        }
    }
}
