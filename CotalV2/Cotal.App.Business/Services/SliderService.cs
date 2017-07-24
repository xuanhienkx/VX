using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Cotal.App.Business.Infrastructure.Extensions;
using Cotal.App.Business.ViewModels.Common;
using Cotal.App.Model.Models;
using Cotal.Core.Domain.Interfaces;
using Cotal.Core.InfacBase.Uow;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cotal.App.Business.Services
{
    public interface ISliderService
    {
        IEnumerable<SlideViewModel> GetAllByStatus(Expression<Func<Slide, bool>> fiter);
        SlideViewModel Get(int id);
        SlideViewModel Get(Expression<Func<Slide, bool>> fiter);
        SlideViewModel Add(SlideViewModel model);
        IResult Update(SlideViewModel model);
        IResult Delete(int id);
        IResult Save();
    }
    public class SliderService : ServiceBace<Slide, int>, ISliderService
    {
        private readonly IMapper _mapper;
        public SliderService(IUowProvider uowProvider, IMapper mapper) : base(uowProvider)
        {
            _mapper = mapper;
        }

        public SlideViewModel Add(SlideViewModel model)
        {
            var db = new Slide();
            db.UpdateSlider(model);
            var rs = Repository.Add(db);
            Save();
            return _mapper.Map<Slide, SlideViewModel>(rs);
        }

        public IResult Delete(int id)
        {
            Repository.Remove(id);
            return Save();
        }

        public SlideViewModel Get(int id)
        {
            var data = Repository.Get(id); 
            return _mapper.Map<Slide, SlideViewModel>(data); 
        }

        public IEnumerable<SlideViewModel> GetAllByStatus(Expression<Func<Slide, bool>> fiter)
        {
            var result = Repository.Query(fiter);
            return _mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(result);
        }

        public SlideViewModel Get(Expression<Func<Slide, bool>> fiter)
        {
            var data = Repository.Query(fiter).FirstOrDefault();
            return _mapper.Map<Slide, SlideViewModel>(data);
        }

        public IResult Save()
        {
            return UnitOfWork.SaveChanges();
        }

        public IResult Update(SlideViewModel model)
        {
            var db = Repository.Get(model.Id);
            db.UpdateSlider(model);
            Repository.Update(db);
            return Save();
        }
    }
}