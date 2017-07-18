using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Cotal.App.Business.Infrastructure.Extensions;
using Cotal.App.Business.ViewModels.Post;
using Cotal.App.Model.Models;
using Cotal.Core.Domain.Interfaces;
using Cotal.Core.InfacBase.Uow;

namespace Cotal.App.Business.Services
{
    public interface IPageService
    {
        IEnumerable<PageViewModel> GetAll(Expression<Func<Page, bool>> filter = null);
        IEnumerable<PageViewModel> GetAll(int page, int pageSize, out int totalRow, Expression<Func<Page, bool>> filter = null);
        PageViewModel GetByAlias(string alias);
        PageViewModel Get(int id);
        PageViewModel Create(PageViewModel page);
        IResult Update(PageViewModel page);
        IResult Delete(int id);
        IResult Save();
    }

    public class PageService : ServiceBace<Page, int>, IPageService
    {
        private readonly IMapper _mapper;
        public PageService(IUowProvider uowProvider, IMapper mapper) : base(uowProvider)
        {
            _mapper = mapper;
        }

        public IEnumerable<PageViewModel> GetAll(Expression<Func<Page, bool>> filter = null)
        {
            var list = Repository.Query(filter);
            return _mapper.Map<IEnumerable<Page>, IEnumerable<PageViewModel>>(list);
        }

        public IEnumerable<PageViewModel> GetAll(int page, int pageSize, out int totalRow, Expression<Func<Page, bool>> filter = null)
        {
            totalRow = Repository.Count(filter);
            var list = Repository.QueryPage(page, pageSize, filter);
            return _mapper.Map<IEnumerable<Page>, IEnumerable<PageViewModel>>(list);
        }

        public PageViewModel GetByAlias(string alias)
        {
            var db = Repository.Query(x => x.Alias == alias).FirstOrDefault();
            return _mapper.Map<Page, PageViewModel>(db);
        }

        public PageViewModel Get(int id)
        {
            var db = Repository.Get(id);
            return _mapper.Map<Page, PageViewModel>(db);
        }

        public PageViewModel Create(PageViewModel page)
        {
            var model = new Page();
            model.UpdatePage(page);
            var db = Repository.Add(model);
            Save();
            return _mapper.Map<Page, PageViewModel>(db);
        }

        public IResult Update(PageViewModel page)
        {
            var model = Repository.Get(page.Id);
            page.CreatedDate = DateTime.Now;
            page.CreatedBy = model.CreatedBy;
            model.UpdatePage(page);
            Repository.Update(model);
            return Save();
        }

        public IResult Delete(int id)
        {
            Repository.Remove(id);
            return Save();
        }

        public IResult Save()
        {
            return UnitOfWork.SaveChanges();
        }
    }
}