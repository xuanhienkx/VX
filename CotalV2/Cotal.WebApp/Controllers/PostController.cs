using System;
using System.Linq;
using Cotal.App.Business.Services;
using Cotal.App.Business.ViewModels.Post;
using Cotal.App.Model.Models;
using Cotal.Core.Domain;
using Cotal.Core.InfacBase.Paging;
using Cotal.Core.InfacBase.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cotal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostController : AdminControllerBase<PostController>
    {
        private readonly IPostService _postService;
        private IDataPager<Post, int> _pager;
        public PostController(ILoggerFactory loggerFactory, IPostService postService, IDataPager<Post, int> pager) : base(loggerFactory)
        {
            _postService = postService;
            _pager = pager;
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public IActionResult GetAll(int? categoryId, string keyword, int page, int pageSize = 20)
        {

            var result = _pager.Query(page, pageSize,
              new Filter<Post>(x => (categoryId == null || x.CategoryId == categoryId)
                        && (string.IsNullOrEmpty(keyword) || x.Name.Contains(keyword) || x.Content.Contains(keyword))),
                     new OrderBy<Post>(p => p.OrderByDescending(o => o.CreatedDate)), posts => posts.Include(c => c.PostCategory));
            return Ok(result);

        }
        [HttpGet("GetTop")]
        [AllowAnonymous]
        public IActionResult GetTop(int top = 10)
        {
            var result = _postService.GetAll(top);
            return Ok(result);
        }
        // GET api/values/5
        [HttpGet("Detail/{id}")]
        public IActionResult Get(int id)
        {
            var p = _postService.GetById(id);
            return Ok(p);
        }
        [HttpPost("Created")]
        public IActionResult Created([FromBody] PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                model.CreatedBy = CurrentUser.UserName;
                model.CreatedDate = DateTime.Now;
                var db = _postService.Add(model);
                return Ok(db);
            }
            catch (Exception e)
            {

                return Error(e);
            }


        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                model.UpdatedBy = CurrentUser.UserName;
                model.UpdatedDate = DateTime.Now;
                var result = _postService.Update(model);
                return Ok(result);
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
                var result = _postService.Delete(id);
                return Ok(result);
            }
            catch (Exception e)
            {

                return Error(e);
            }

        }
    }
}
