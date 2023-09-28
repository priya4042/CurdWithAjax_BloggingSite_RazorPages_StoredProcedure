using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWith_AzureFunction
{
   public class Post
    {
        public string PostId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
        //[BindProperty, DataType(DataType.Date)]

        public DateTime UpdatedOn { get; set; }
    }
}
