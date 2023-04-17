import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentModule } from './department/department.module';
import { DepartmentsComponent, ViewDepartmentComponent, CatalogsComponent } from './department/components';
import { SigninCallbackComponent } from './core/components/signin-callback/signin-callback.component';

const routes: Routes = [
  { path: 'signin-callback', component: SigninCallbackComponent},
  { path: 'departments', component: DepartmentsComponent},
  { path: 'departments/:id', component: ViewDepartmentComponent},
  { path: 'catalogs', component: CatalogsComponent},
  { path: '**', redirectTo: 'departments'},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    DepartmentModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
