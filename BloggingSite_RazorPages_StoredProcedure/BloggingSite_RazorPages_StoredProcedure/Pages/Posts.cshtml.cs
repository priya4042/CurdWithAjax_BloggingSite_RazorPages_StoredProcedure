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
    
    public class PostsModel : PageModel
    {
        PostDA postDA = new PostDA();
        public void OnGet()
        {
        }

        [BindProperty]
        public Post post { get; set; }

        public ActionResult OnPostAdd()
        {
            post.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            postDA.AddPost(post);

            return RedirectToPage("./Blog");
        }


    }
}
