import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cart } from '../Models/Cart';
import { CartApiService } from '../Services/cart-api.service';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(private cartApi : CartApiService, private router : Router) { }

  foundCart : Cart = 
  this.cartApi.FindCartByUserId(1).subscribe(cart => this.foundCart=cart) 

  ngOnInit(): void {
  }

}
