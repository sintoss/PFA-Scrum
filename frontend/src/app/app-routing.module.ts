import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {LandingComponent} from './landing/landing.component';

const routes: Routes = [
  /*{ path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },*/
  {
    path: '',
    component: LandingComponent
  },
  {path: '', loadChildren: () => import('./user/user.module').then(m => m.UserModule)},
  {path: 'release', loadChildren: () => import('./release/release.module').then(m => m.ReleaseModule)},
  {path: 'projets', loadChildren: () => import('./projet/projet.module').then(m => m.ProjetModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
