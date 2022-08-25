using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DataAccess;
using DataAccess.Entities;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Services;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProductController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpPut]
        public JsonResult Put(Product product)
        {
            return new JsonResult("Successfully Updated");
        }

       [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string ProductImage = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "../Photos/" + ProductImage;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(ProductImage);

            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }
    }
}
