using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProjectWith_AzureFunction
{
    public static class GetAllData
    {
        [FunctionName("GetAllData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            List<Post> posts= new List<Post>();
            string EmployeeId = string.Empty;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            posts = data?.PostId;


         
                posts = new List<Post>();
                
                    posts.Add(new Post() { PostId="1", Title = $"Blogger is an American online content management system which enables multi-user blogs with time-stamped entries. Pyra Labs developed it before being acquired by Google in 2003. Google hosts the blogs, which can be accessed through a subdomain of blogspot.com.", CreatedOn  = DateTime.Now.AddDays(-1), UpdatedOn = DateTime.Now.AddDays(1) });
                

                return (ActionResult)new OkObjectResult(posts);
           


        }
    }
}
