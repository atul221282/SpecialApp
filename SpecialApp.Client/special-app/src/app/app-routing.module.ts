import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  // { path: '', pathMatch: 'full', redirectTo: '/account/login' },
  { path: 'special', loadChildren: 'app/special/special.module#SpecialModule' },
  // { path: '**', pathMatch: 'full', component: PageNotFoundComponent },

//TODO: Remove this later on as by default user should be redirected to login page
  { path: '', pathMatch: 'full', redirectTo: '/special' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routableComponents = [];

