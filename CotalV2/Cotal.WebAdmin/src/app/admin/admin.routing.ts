import { NgModule } from '@angular/core';
import { Routes,RouterModule } from "@angular/router";
import { AdminComponent } from "./admin.component";

export const adminRouting: Routes = [
    {
        path: '', component: AdminComponent, children: [
            { path: '', redirectTo: 'home', pathMatch: 'full' }, 
            { path: 'home', loadChildren: './home/home.module#HomeModule' },
            { path: 'user', loadChildren: './user/user.module#UserModule' },
            { path: 'role', loadChildren: './role/role.module#RoleModule' },
            { path: 'function', loadChildren: './function/function.module#FunctionModule' },
            { path: 'post-category', loadChildren: './post-category/post-category.module#PostCategoryModule' },
            { path: 'post', loadChildren: './post/post.module#PostModule' },
            { path: 'page', loadChildren: './page/page.module#PageModule' },
            { path: 'slider', loadChildren: './slider/slider.module#SliderModule' },
            { path: 'service', loadChildren: './provider/provider.module#ProviderModule' }
        ]
    }
];
@NgModule({
  imports: [RouterModule.forChild(adminRouting)],
  exports: [RouterModule]
})

export class AdminRoutingModule { }