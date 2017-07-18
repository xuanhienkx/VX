using AutoMapper;
using Cotal.App.Business.ViewModels.Common;
using Cotal.App.Business.ViewModels.Post;
using Cotal.App.Business.ViewModels.System;
using Cotal.App.Model.Models;
using Cotal.Core.Identity.Models;

namespace Cotal.App.Business.Mappings
{
  public class ViewModelMappingProfile : Profile
  {
    public ViewModelMappingProfile()
    {
      CreateMap<Function, FunctionViewModel>();
      CreateMap<Announcement, AnnouncementViewModel>();
      CreateMap<AnnouncementUser, AnnouncementUserViewModel>();
      CreateMap<AppUser, AppUserViewModel>();
      CreateMap<AppRole, AppRoleViewModel>();
      CreateMap<Permission, PermissionViewModel>();
      CreateMap<Post, PostViewModel>();
      CreateMap<PostCategory, PostCategoryViewModel>();
      CreateMap<Tag, TagViewModel>();
      CreateMap<Footer, FooterViewModel>();
      CreateMap<Slide, SlideViewModel>();
      CreateMap<Page, PageViewModel>();
    } 
  }
}