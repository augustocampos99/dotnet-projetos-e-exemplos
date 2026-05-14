import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BankStatementComponent } from './bank-statement-component/bank-statement-component';



@NgModule({
  declarations: [
    BankStatementComponent
  ],
  imports: [
    RouterModule.forChild([
      { path: 'bank-statement', component: BankStatementComponent },
    ]),
    CommonModule
  ]
})
export class BankStatementModule { }
