using System.Collections.Generic;
using AutoMapper;
using Cotal.App.Business.Infrastructure.Extensions;
using Cotal.App.Business.ViewModels.Post;
using Cotal.App.Model.Models;
using Cotal.Core.Domain.Interfaces;
using Cotal.Core.InfacBase.Uow;

namespace Cotal.App.Business.Services
{
    public interface IPostCategoryService
    {
        PostCategoryViewModel Add(PostCategoryViewModel postCategory);

        IResult Update(PostCategoryViewModel postCategory);

        IResult Delete(int id);

        IEnumerable<PostCategoryViewModel> GetAll(string filter);

        IEnumerable<PostCategoryViewModel> GetAllByParentId(int? parentId);

        PostCategoryViewModel GetById(int id);

        IResult Save();
    }

    public class PostCategoryService : ServiceBace<PostCategory, int>, IPostCategoryService
    {
        private readonly IMapper _mapper;
        public PostCategoryService(IUowProvider uowProvider, IMapper mapper) : base(uowProvider)
        {
            _mapper = mapper;
        }

        public PostCategoryViewModel Add(PostCategoryViewModel postCategory)
        {
            var db = new PostCategory();
            db.UpdatePostCategory(postCategory);
            var newDb = Repository.Add(db); 
            Save();
            var viewModel = _mapper.Map<PostCategory, PostCategoryViewModel>(newDb);
            return viewModel;
        }

        public IResult Update(PostCategoryViewModel postCategory)
        {
            var db = Repository.Get(postCategory.Id);
            postCategory.CreatedBy = db.CreatedBy;
            postCategory.CreatedDate = db.CreatedDate;
            db.UpdatePostCategory(postCategory);
            Repository.Update(db);
            return Save();
        }

        public IResult Delete(int id)
        {
            Repository.Remove(id);
            return Save();
        }

        public IEnumerable<PostCategoryViewModel> GetAll(string filter)
        {
            var list = Repository.Query(x => string.IsNullOrEmpty(filter) || x.Name.Contains(filter));
            var viewModel = _mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(list);
            return viewModel;
        }

        public IEnumerable<PostCategoryViewModel> GetAllByParentId(int? parentId)
        {
            var list = Repository.Query(x => parentId == null || x.ParentId == parentId);
            var viewModel = _mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(list);
            return viewModel;
        }

        public PostCategoryViewModel GetById(int id)
        {
            var db = Repository.Get(id);
            return _mapper.Map<PostCategory, PostCategoryViewModel>(db);
        }

        public IResult Save()
        {
            return UnitOfWork.SaveChanges();
        }
    }
}