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
    public class DeletePostsModel : PageModel
    {
        PostDA post = new PostDA();

        public Post posts { get; set; }

        public ActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
             post.GetPostData(id);

            if (post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            post.DeletePost(id);

            return RedirectToPage("./IndexPages");
        }
    }
}

