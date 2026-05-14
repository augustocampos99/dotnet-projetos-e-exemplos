import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CreditCardComponent } from './credit-card-component/credit-card-component';



@NgModule({
  declarations: [
    CreditCardComponent
  ],
  imports: [
    RouterModule.forChild([
      { path: 'credit-card', component: CreditCardComponent },
    ]),
    CommonModule
  ]
})
export class CreditCardModule { }
