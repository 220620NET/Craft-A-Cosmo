import { NgModule } from '@angular/core';
import { Routes } from '@angular/router'; 
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CartComponent } from './cart/cart.component';
import { ReactiveFormsModule } from '@angular/forms';



const routes: Routes = [
  {
    path: 'cart', 
    component : CartComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
