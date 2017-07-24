using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Cotal.App.Business.Infrastructure.Extensions;
using Cotal.App.Business.ViewModels.Common;
using Cotal.App.Model.Models;
using Cotal.Core.Common.Enums;
using Cotal.Core.Domain.Interfaces;
using Cotal.Core.InfacBase.Uow;

namespace Cotal.App.Business.Services
{
    public interface IProviderServices
    {
        OutServiceModel Add(OutServiceModel model);

        IResult Update(OutServiceModel model);

        IResult Delete(int id);

        IEnumerable<OutServiceModel> GetAll(Expression<Func<OutService, bool>> fiter = null);
        IEnumerable<OutServiceModel> GetAll(int top = 10, Expression<Func<OutService, bool>> fiter = null);

        OutServiceModel GetById(int id);

        IResult Save();
    }
    public class ProviderServices : ServiceBace<OutService, int>, IProviderServices
    {
        private readonly IMapper _mapper;
        public ProviderServices(IUowProvider uowProvider, IMapper mapper) : base(uowProvider)
        {
            _mapper = mapper;
        }

        public OutServiceModel Add(OutServiceModel model)
        {
            var outProvider = new OutService();
            outProvider.UpdateOutService(model);
            var db = Repository.Add(outProvider);
            Save();
            return _mapper.Map<OutService, OutServiceModel>(db);
        }

        public IResult Update(OutServiceModel model)
        {
            var outProvider = Repository.Get(model.Id);
            outProvider.UpdateOutService(model);
            Repository.Update(outProvider);
            return Save();

        }

        public IResult Delete(int id)
        { 
            Repository.Remove(id);
            return Save();
        }

        public IEnumerable<OutServiceModel> GetAll(Expression<Func<OutService, bool>> fiter = null)
        {
            var data = Repository.Query(fiter).ToList();
            return _mapper.Map<IEnumerable<OutService>, IEnumerable<OutServiceModel>>(data);
        }

        public IEnumerable<OutServiceModel> GetAll(int top = 10, Expression<Func<OutService, bool>> fiter = null)
        {
            var data = Repository.Query(fiter).Take(top).ToList();
            return _mapper.Map<IEnumerable<OutService>, IEnumerable<OutServiceModel>>(data);
        }

        public OutServiceModel GetById(int id)
        {
            var db = Repository.Get(id);
            return _mapper.Map<OutService, OutServiceModel>(db);
        }

        public IResult Save()
        {
            return UnitOfWork.SaveChanges();
        }
    }
}