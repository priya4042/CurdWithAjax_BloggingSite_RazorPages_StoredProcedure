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
    public class AjaxPageModel : PageModel
    {
        PostDA postDA = new PostDA();

        public void OnGet()
        {
        }

        //with this data display on indexpages
        public JsonResult OnGetList()
        {
            postList = postDA.GetAllPost();
            return new JsonResult(postList);
            
        }

        //with this we create/save new data
        public JsonResult OnGetSave(Post post)
        {
            var ps = new Post()
            {
                Title = post.Title,
                Description = post.Description,
                UserName = post.UserName
            };
             postDA.AddPost(ps);
            return new JsonResult("Data Saved");
        }

        //Code for get data getby id
        public JsonResult OnGetEdit(int? id)
        {
          var post = postDA.GetPostData(id);

            return new JsonResult(post);
        }
      
        //code for update data
       public IActionResult OnGetUpdate(Post post)
        {
            postDA.UpdatePost(post);
            return new JsonResult("Data Saved");
        }


        //code for Delete data
        public JsonResult OnGetDelete(int? id)
        {          
            postDA.DeletePost(id);
            return new JsonResult("DataDeleted");
        }

       

        [BindProperty]
        public IEnumerable<Post> postList { get; set; }
    }
}
