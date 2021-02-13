using API.Core.DbModels;
using API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class HomeController : ControllerBase
    {
        private readonly IGenericRepository<MainReference> _mainReference;
        private readonly IGenericRepository<MainNews> _mainNews;
        private readonly IGenericRepository<MainCompany> _mainCompany;
        private readonly IGenericRepository<MainActivity> _mainActivity;

        public HomeController(IGenericRepository<MainReference> mainReference, IGenericRepository<MainNews> mainNews,
            IGenericRepository<MainCompany> mainCompany, IGenericRepository<MainActivity> mainActivity)
        {
            _mainReference = mainReference;
            _mainCompany = mainCompany;
            _mainNews = mainNews;
            _mainActivity = mainActivity;
        }
        [Authorize]
        [HttpGet("news")]
        public async Task<ActionResult<MainNews>> MainNews()
        {
            var data = await _mainNews.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("reference")]
        public async Task<ActionResult<MainReference>> MainReference()
        {
            var data = await _mainReference.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("Activity")]
        public async Task<ActionResult<MainActivity>> MainActivity()
        {
            var data = await _mainActivity.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("Company")]
        public async Task<ActionResult<MainCompany>> MainCompany()
        {
            var data = await _mainActivity.ListAllAsync();
            return Ok(data);
        }

    }
}
