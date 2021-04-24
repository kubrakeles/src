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
    [Authorize]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGenericRepository<MainReference> _mainReference;
        private readonly IGenericRepository<MainNews> _mainNews;
        private readonly IGenericRepository<MainCompany> _mainCompany;
        private readonly IGenericRepository<MainActivity> _mainActivity;
        private readonly IGenericRepository<MainSlider_Image> _mainSlider;

        public HomeController(IGenericRepository<MainReference> mainReference, IGenericRepository<MainNews> mainNews,
            IGenericRepository<MainCompany> mainCompany, IGenericRepository<MainActivity> mainActivity,
            IGenericRepository<MainSlider_Image> mainSlider)
        {
            _mainReference = mainReference;
            _mainCompany = mainCompany;
            _mainNews = mainNews;
            _mainActivity = mainActivity;
            _mainSlider = mainSlider;
        }
        /// <summary>
        /// news get,add,update,delete
        /// </summary>
        /// <returns></returns>

        [HttpGet("news")]
        public async Task<ActionResult<MainNews>> MainNews()
        {
             var data = await _mainNews.ListAllAsync();
            return Ok(data);
        }

        [HttpGet("NewsById")]
        public async Task<ActionResult<MainNews>> MainNewsById(int id)
        {
            var data = await _mainNews.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost(template: "AddNews")]
        public ActionResult AddNews(MainNews news)
        {
            var result = _mainNews.add(news);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "UpdateNews")]
        public ActionResult UpdateNews(MainNews news)
        { 
            var result = _mainNews.update(news);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "DeleteNews")]
        public ActionResult Delete(MainNews news)
        {
            var result = _mainNews.delete(news);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);

        }

        /// <summary>
        /// Reference add,get,delete,update
        /// </summary>
        /// <returns></returns>
        [HttpGet("reference")]
        public async Task<ActionResult<MainReference>> MainReference()
        {
            var data = await _mainReference.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("ReferenceById")]
        public async Task<ActionResult<MainNews>> MainReferenceById(int id)
        {
            var data = await _mainReference.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost(template: "AddReference")]
        public ActionResult AddReference(MainReference reference)
        {
            var result = _mainReference.add(reference);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "UpdateReference")]
        public ActionResult UpdateReference(MainReference reference)
        {
            var result = _mainReference.update(reference);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "DeleteReference")]
        public ActionResult DeleteReference(MainReference reference)
        {
            var result = _mainReference.delete(reference);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);

        }
        /// <summary>
        /// Activity get,add,update,delete işlemleri
        /// </summary>
        /// <returns></returns>




        [HttpGet("Activity")]
        public async Task<ActionResult<MainActivity>> MainActivity()
        {
            var data = await _mainActivity.ListAllAsync();
            return Ok(data);
        }
        [HttpPost(template: "AddActivity")]
        public ActionResult AddActivity(MainActivity activity)
        {
            var result = _mainActivity.add(activity);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "UpdateActivity")]
        public ActionResult UpdateActivity(MainActivity activity)
        {
            var result = _mainActivity.update(activity);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "DeleteActivity")]
        public ActionResult DeleteActivity(MainActivity activity)
        {
            var result = _mainActivity.delete(activity);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);

        }
        /// <summary>
        /// Company add,get,update, delete işlemleri
        /// </summary>
        /// <returns></returns>




        [HttpGet("Company")]
        public async Task<ActionResult<MainCompany>> MainCompany()
        {
            var data = await _mainCompany.ListAllAsync();
            return Ok(data);
        }
        [HttpPost(template: "AddCompany")]
        public ActionResult AddCompany(MainCompany company)
        {
            var result = _mainCompany.add(company);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "UpdateCompany")]
        public ActionResult UpdateCompany(MainCompany company)
        {
            var result = _mainCompany.update(company);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "DeleteCompany")]
        public ActionResult DeleteCompany(MainCompany company)
        {
            var result = _mainCompany.delete(company);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);



        }
    }
}
