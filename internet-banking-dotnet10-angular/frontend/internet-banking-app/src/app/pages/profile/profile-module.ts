import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProfileComponent } from './profile-component/profile-component';



@NgModule({
  declarations: [
    ProfileComponent
  ],
  imports: [
    RouterModule.forChild([
      { path: 'profile', component: ProfileComponent },
    ]),
    CommonModule
  ]
})
export class ProfileModule { }
