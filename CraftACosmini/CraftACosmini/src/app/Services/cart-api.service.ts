import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from '../Models/Cart';
import { Product } from '../Models/Product';


@Injectable({
  providedIn: 'root'
})
export class CartApiService 
{
  
  constructor(private http: HttpClient) { }
  // url : string = environment.api;
  url : string = "";
  CreateCart(cartToCreate : Cart) : Observable<Cart> {
    return this.http.get(this.url + `createCart?cartToCreate=${cartToCreate}`) as Observable<Cart>;  
  }

  UpdateBillingAddress(UpdateBillingAddress : Cart) : Observable<Cart> {
    return this.http.get(this.url + `updateBilling?UpdateBillingAddress=${UpdateBillingAddress}`) as Observable<Cart>;  
  }

  UpdateShippingAddress(UpdateShippingAddress : Cart) : Observable<Cart> {
    return this.http.get(this.url + `updateAddress?UpdateShippingAddress=${UpdateShippingAddress}`) as Observable<Cart>;  
  }

  DeleteCart(cartToDelete : Cart) : Observable<Cart> {
      return this.http.get(this.url + `deleteCart?CartToDelete${cartToDelete}`) as Observable<Cart>; 
  }

  AdjustItems(cartId : number, productToAdd : Product, quantity : number ) : Observable<Cart> {
  return this.http.get(this.url + `adjustItems?cartId=${cartId}&productToAdd=${productToAdd}&quantity=${quantity}`) as Observable<Cart>; 
  }

  ConfirmPurchase(cartToPurchase : Cart) : Observable<Cart> {
    return this.http.get(this.url + `confirmPurchase?cartToPurchase=${cartToPurchase}`) as Observable<Cart>; 
  }

  FindCartByUserId(userId2Find : number) : Observable<Cart[]> {
    return this.http.get(this.url + `findCart?userIdToFind=${userId2Find}`) as Observable<Cart[]>; 
  }

}
