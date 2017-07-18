using Cotal.App.Model.Models;
using Cotal.Core.Domain.Interfaces;
using Cotal.Core.InfacBase.Uow;

namespace Cotal.App.Business.Services
{
  public interface IFeedbackService
  {
    Feedback Create(Feedback feedback);

      IResult Save();
  }

  public class FeedbackService : ServiceBace<Feedback, int>, IFeedbackService
  {
    public FeedbackService(IUowProvider uowProvider) : base(uowProvider)
    {
    }

    public Feedback Create(Feedback feedback)
    {
      return Repository.Add(feedback);
    }

    public IResult Save()
    {
      return UnitOfWork.SaveChanges();
    }
  }
}