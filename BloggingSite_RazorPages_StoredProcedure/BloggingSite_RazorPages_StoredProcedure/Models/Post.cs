using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSite_RazorPages_StoredProcedure.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
        //[BindProperty, DataType(DataType.Date)]

        public DateTime UpdatedOn { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public int UserId { get; set; }
    }
}
