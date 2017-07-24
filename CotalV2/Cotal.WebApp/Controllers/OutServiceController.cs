using System;
using System.Globalization;
using System.Linq;
using Cotal.App.Business.Services;
using Cotal.App.Business.ViewModels.Common;
using Cotal.App.Business.ViewModels.Post;
using Cotal.App.Model.Models;
using Cotal.Core.Common.Enums;
using Cotal.Core.InfacBase.Paging;
using Cotal.Core.InfacBase.Query;
using Cotal.WebAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cotal.WebApp.Controllers
{ 
    [Route("api/[controller]")]
    public class OutServiceController : AdminControllerBase<OutServiceController>
    {
        private readonly IDataPager<OutService, int> _dataPager;
        private readonly IProviderServices _services;
        public OutServiceController(ILoggerFactory loggerFactory, IProviderServices services, IDataPager<OutService, int> dataPager) : base(loggerFactory)
        {
            _services = services;
            _dataPager = dataPager;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int page, int pageSize = 20, string keyword = "")
        {
            var result = _dataPager.Query(page, pageSize,
                new Filter<OutService>(
                    x => (string.IsNullOrEmpty(keyword) || x.Name.Contains(keyword) || x.Content.Contains(keyword))));
            return Ok(result);
        }
        [HttpGet("GetAllClient")]
        [AllowAnonymous]
        public IActionResult GetAllClient(string keyword = "")
        {
            var result = _services.GetAll(x => x.Status && x.Name.Contains(keyword));
            return Ok(result);
        } 
        [HttpGet("Detail/{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            var p = _services.GetById(id);
            return Ok(p);
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]OutServiceModel model)
        {
            try
            { 
                var db = _services.Add(model);
                return Ok(db);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]OutServiceModel model)
        {
            try
            { 
                var data = _services.Update(model);
                return Ok(data);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _services.Delete(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return Error(e);
            }

        }

    }
}