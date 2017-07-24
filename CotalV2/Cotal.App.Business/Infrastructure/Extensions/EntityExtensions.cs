﻿using System;
using System.Globalization;
using Cotal.App.Business.ViewModels.Common;
using Cotal.App.Business.ViewModels.Post;
using Cotal.App.Business.ViewModels.System;
using Cotal.App.Model.Models;
using Cotal.Core.Common.Enums;
using Cotal.Core.Identity.Models;

namespace Cotal.App.Business.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.Id = postCategoryVm.Id;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentId = postCategoryVm.ParentId;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;
        }

        public static void UpdateSlider(this Slide slide, SlideViewModel model)
        {
            slide.Id = model.Id;
            slide.Name = model.Name;
            slide.Description = model.Description;
            slide.Image = model.Image;
            slide.Content = model.Content;
            slide.Status = model.Status;
            slide.Url = model.Url;
            slide.DisplayOrder = model.DisplayOrder;
            slide.SlideType = model.SlideType;
        }
        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.Id = postVm.Id;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryId = postVm.CategoryId;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;

            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;
        }
        public static void UpdateOutService(this OutService service, OutServiceModel serviceModel)
        {
            service.Id = serviceModel.Id;
            service.Name = serviceModel.Name;
            service.Description = serviceModel.Description;
            service.Alias = serviceModel.Alias; 
            service.Content = serviceModel.Content;
            service.Image = serviceModel.Image;
            service.HomeFlag = serviceModel.HomeFlag; 
            service.Status = serviceModel.Status;
            service.IconCss = serviceModel.IconCss;
            service.HotFlag = serviceModel.HotFlag;

            service.CreatedDate = serviceModel.CreatedDate;
            service.CreatedBy = serviceModel.CreatedBy;
            service.UpdatedDate = serviceModel.UpdatedDate;
            service.UpdatedBy = serviceModel.UpdatedBy;
            service.MetaKeyword = serviceModel.MetaKeyword;
            service.MetaDescription = serviceModel.MetaDescription;
        }


        public static void UpdatePage(this Page page, PageViewModel pageView)
        {
            page.Id = pageView.Id;
            page.Name = pageView.Name;
            page.Content = pageView.Content;
            page.Status = pageView.Status;
            page.Alias = pageView.Alias;
            page.CreatedBy = pageView.CreatedBy;
            page.CreatedDate = pageView.CreatedDate;
            page.MetaDescription = pageView.MetaDescription;
            page.MetaKeyword = pageView.MetaKeyword;
            page.UpdatedBy = pageView.UpdatedBy;
            page.UpdatedDate = pageView.UpdatedDate;
        }
        /* public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
          {
              productCategory.Id = productCategoryVm.ID;
              productCategory.Name = productCategoryVm.Name;
              productCategory.Description = productCategoryVm.Description;
              productCategory.Alias = productCategoryVm.Alias;
              productCategory.ParentId = productCategoryVm.ParentID;
              productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
              productCategory.HomeOrder = productCategoryVm.HomeOrder;
              productCategory.Image = productCategoryVm.Image;
              productCategory.HomeFlag = productCategoryVm.HomeFlag;
              productCategory.HomeOrder = productCategoryVm.HomeOrder;
              productCategory.CreatedDate = productCategoryVm.CreatedDate;
              productCategory.CreatedBy = productCategoryVm.CreatedBy;
              productCategory.UpdatedDate = productCategoryVm.UpdatedDate;
              productCategory.UpdatedBy = productCategoryVm.UpdatedBy;
              productCategory.MetaKeyword = productCategoryVm.MetaKeyword;
              productCategory.MetaDescription = productCategoryVm.MetaDescription;
              productCategory.Status = productCategoryVm.Status;
          }*/
        /*        public static void UpdateProduct(this Product product, ProductViewModel productVm)
                {
                    product.ID = productVm.ID;
                    product.Name = productVm.Name;
                    product.Description = productVm.Description;
                    product.Alias = productVm.Alias;
                    product.CategoryID = productVm.CategoryID;
                    product.Content = productVm.Content;
                    product.ThumbnailImage = productVm.ThumbnailImage;
                    product.Price = productVm.Price;
                    product.PromotionPrice = productVm.PromotionPrice;
                    product.Warranty = productVm.Warranty;
                    product.HomeFlag = productVm.HomeFlag;
                    product.HotFlag = productVm.HotFlag;
                    product.ViewCount = productVm.ViewCount;

                    product.CreatedDate = productVm.CreatedDate;
                    product.CreatedBy = productVm.CreatedBy;
                    product.UpdatedDate = productVm.UpdatedDate;
                    product.UpdatedBy = productVm.UpdatedBy;
                    product.MetaKeyword = productVm.MetaKeyword;
                    product.MetaDescription = productVm.MetaDescription;
                    product.Status = productVm.Status;
                    product.Tags = productVm.Tags;
                    product.OriginalPrice = productVm.OriginalPrice;
                }*/
        /* public static void UpdateProductQuantity(this ProductQuantity quantity, ProductQuantityViewModel quantityVm)
{
    quantity.ColorId = quantityVm.ColorId;
    quantity.ProductId = quantityVm.ProductId;
    quantity.SizeId = quantityVm.SizeId;
    quantity.Quantity = quantityVm.Quantity;
}
public static void UpdateOrder(this Order order, OrderViewModel orderVm)
{
    order.CustomerName = orderVm.CustomerName;
    order.CustomerAddress = orderVm.CustomerAddress;
    order.CustomerEmail = orderVm.CustomerEmail;
    order.CustomerMobile = orderVm.CustomerMobile;
    order.CustomerMessage = orderVm.CustomerMessage;
    order.PaymentMethod = orderVm.PaymentMethod;
    order.CreatedDate = DateTime.Now;
    order.CreatedBy = orderVm.CreatedBy;
    order.PaymentStatus = orderVm.PaymentStatus;
    order.Status = orderVm.Status;
    order.CustomerId = orderVm.CustomerId;
}

public static void UpdateProductImage(this ProductImage image, ProductImageViewModel imageVm)
{
    image.ProductId = imageVm.ProductId;
    image.Path = imageVm.Path;
    image.Caption = imageVm.Caption;
}*/

        public static void UpdateFeedback(this Feedback feedback, FeedbackViewModel feedbackVm)
        {
            feedback.Name = feedbackVm.Name;
            feedback.Email = feedbackVm.Email;
            feedback.Message = feedbackVm.Message;
            feedback.Status = feedbackVm.Status;
            feedback.CreatedDate = DateTime.Now;
        }

        public static void UpdateFunction(this Function function, FunctionViewModel functionVm)
        {
            function.Name = functionVm.Name;
            function.DisplayOrder = functionVm.DisplayOrder;
            function.IconCss = functionVm.IconCss;
            function.Status = functionVm.Status;
            function.ParentId = functionVm.ParentId;
            function.Status = functionVm.Status;
            function.URL = functionVm.URL;
            function.Id = functionVm.Id;
            function.FunctionType = functionVm.FunctionType;
        }

        public static void UpdatePermission(this Permission permission, PermissionViewModel permissionVm)
        {
            permission.RoleId = permissionVm.RoleId;
            permission.FunctionId = permissionVm.FunctionId;
            permission.CanCreate = permissionVm.CanCreate;
            permission.CanDelete = permissionVm.CanDelete;
            permission.CanRead = permissionVm.CanRead;
            permission.CanUpdate = permissionVm.CanUpdate;
        }

        public static void UpdateApplicationRole(this AppRole appRole, AppRoleViewModel appRoleViewModel,
          string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }

        public static void UpdateUser(this AppUser appUser, AppUserViewModel appUserViewModel, string action = "add")
        {
            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            if (!string.IsNullOrEmpty(appUserViewModel.BirthDay))
            {
                var dateTime = DateTime.ParseExact(appUserViewModel.BirthDay, "dd/MM/yyyy", new CultureInfo("vi-VN"));
                appUser.BirthDay = dateTime;
            }

            appUser.Email = appUserViewModel.Email;
            appUser.Address = appUserViewModel.Address;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
            appUser.Gender = appUserViewModel.Gender == "True" ? true : false;
            appUser.Status = appUserViewModel.Status;
            appUser.Address = appUserViewModel.Address;
            appUser.Avatar = appUserViewModel.Avatar;
        }
    }
}