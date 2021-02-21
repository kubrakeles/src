using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.Implements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private IGenericRepository<ProductImage> _genericrepository;
        public FileUploadController(IWebHostEnvironment webHostEnvironment,IGenericRepository<ProductImage> genericRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _genericrepository = genericRepository;
        }
        [HttpPost(template:"AddFile")]
        [Authorize]
        public string Post([FromForm]IFormFile formFile,int ProductId)
        {
            try
            {
                if (formFile.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    _genericrepository.add(new ProductImage()
                    {
                        productID = ProductId,
                        PictureUrl = path
                    });
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream=System.IO.File.Create(path+formFile.FileName))
                    {
                        formFile.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Uploaded";
                    }
                }
                else
                {
                    return "Yüklenmedi";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;         
            }
        }
    }
}
