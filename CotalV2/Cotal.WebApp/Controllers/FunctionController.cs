using System;
using System.Collections.Generic;
using System.Linq;
using Cotal.App.Business.Services;
using Cotal.App.Business.ViewModels.System;
using Cotal.App.Model.Models;
using Cotal.Core.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cotal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FunctionController : AdminControllerBase<FunctionController>
    {
        private readonly IFunctionService _functionService;

        public FunctionController(IFunctionService functionService, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _functionService = functionService;
        }


        [HttpGet("GetAllHierachy")]
        public IActionResult GetAllHierachy()
        {
            IEnumerable<FunctionViewModel> model;
            model = CurrentRoleNames.Contains("Administrator")
              ? _functionService.GetAll(string.Empty, FunctionType.Admin)
              : _functionService.GetAllWithPermission(CurrentRoleIds, FunctionType.Admin);

            var parents = model.Where(x => x.Parent == null).ToList();
            foreach (var parent in parents)
                parent.ChildFunctions = model.Where(x => x.ParentId == parent.Id).ToList();

            return Ok(parents);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(string filter = "")
        {
            var model = _functionService.GetAll(filter);
            return Ok(model);
        }
        [HttpGet("Detail/{id}")]
        public IActionResult Detail(string id)
        {
            var function = _functionService.Get(id);
            return Ok(function);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody]FunctionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {

                var function = _functionService.Create(model);
                return Ok(function);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody]FunctionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {

                var result = _functionService.Update(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Error(e);
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = _functionService.Delete(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Error(e);
            }

        }

    }
}
