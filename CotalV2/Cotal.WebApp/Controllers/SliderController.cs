using System;
using System.Linq;
using Cotal.App.Business.Services;
using Cotal.App.Business.ViewModels.Common;
using Cotal.App.Model.Models;
using Cotal.Core.Domain;
using Cotal.Core.InfacBase.Paging;
using Cotal.Core.InfacBase.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cotal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SliderController : AdminControllerBase<SliderController>
    {
        private readonly ISliderService _sliderService;
        private readonly IDataPager<Slide, int> _dataPager;
        public SliderController(ILoggerFactory loggerFactory, IDataPager<Slide, int> dataPager, ISliderService sliderService) : base(loggerFactory)
        {
            _dataPager = dataPager;
            _sliderService = sliderService;
        }
        // GET: api/values
        [HttpGet("GetAll")]
        public IActionResult GetAll(int? page, int pageSize = 20, string keyword = "")
        {
            page = page ?? 1;
            var result = _dataPager.Query(page.Value, pageSize,
                new Filter<Slide>(
                    x => (string.IsNullOrEmpty(keyword) || x.Name.Contains(keyword) || x.Content.Contains(keyword))));
            return Ok(result);
        }
        [HttpGet("GetAllActive/{type}")]
        [AllowAnonymous]
        public IActionResult GetAllActive(SlideType type)
        {

            var result = _sliderService.GetAllByStatus(x => x.Status && x.SlideType.Equals(type)).ToList();
            return Ok(result);
        }
        [HttpGet("Detail/{id}")]
        public IActionResult Get(int id)
        {
            var data = _sliderService.Get(id);
            return Ok(data);
        }
        [HttpPost("Add")]
        public IActionResult Post([FromBody] SlideViewModel model)
        {

            try
            {
                var data = _sliderService.Add(model);
                return Ok(data);
            }
            catch (Exception e)
            {

                return Error(e);
            }
        }
        [HttpPut("Update")]
        public IActionResult Put([FromBody] SlideViewModel model)
        {
            try
            {
                var data = _sliderService.Update(model);
                return Ok(data);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _sliderService.Delete(id);
                return Ok(data);
            }
            catch (Exception e)
            {

                return Error(e);
            }
        }
    }
}