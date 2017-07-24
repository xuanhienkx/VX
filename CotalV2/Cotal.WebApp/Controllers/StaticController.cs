using System;
using System.Reflection;
using Cotal.Core.Common.Enums;
using Cotal.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cotal.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class StaticController: ControllerBase<StaticController>
    {
        public StaticController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }
        [HttpGet("GetEnumAsList")]
        public IActionResult GetEnumAsList(string name)
        {
            var list = EnumExtensions.GetObjectListByType(name);
            return Ok(list);
        }
    }
}