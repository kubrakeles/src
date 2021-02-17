using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.Implements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private  IGenericRepository<CompanyInfo> _genericRepository;
        public InfoController(IGenericRepository<CompanyInfo> genericRepository )
        {
            _genericRepository = genericRepository;
        }
      
        [HttpGet("info")]
        public async Task<ActionResult<CompanyInfo>> CompanyInfo()
        {
            var data = await _genericRepository.ListAllAsync();
            return Ok(data);
        }
        [HttpPost(template: "AddInfo")]
        public ActionResult AddNews(CompanyInfo company)
        {
            var result = _genericRepository.add(company);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "UpdateInfo")]
        public ActionResult UpdateNews(CompanyInfo company)
        {
            var result = _genericRepository.update(company);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "DeleteInfo")]
        public ActionResult Delete(CompanyInfo company)
        {
            var result = _genericRepository.delete(company);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);

        }
    }
}
