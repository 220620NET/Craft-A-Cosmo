using DataAccess.Interface;
using DataAccess.Entities;
using CustomExceptions;
using Microsoft.EntityFrameworkCore;


namespace DataAccess;

public class CartRepo : ICartDAO
{
  private readonly p3dbContext _context;
  
  public CartRepo(p3dbContext context)
  {
    _context = context;
  }

  /// <inheritdoc />
  public Cart CreateCart(Cart cartToCreate)
  {
    _context.Add(cartToCreate);
    _context.SaveChanges(); //persist the change
    _context.ChangeTracker.Clear(); //clear the tracker for the next person
    return cartToCreate;
  }

  /// <inheritdoc />
  public Cart AdjustItems(int cartToUpdate, Item itemToAdd)
  {
    Cart? Cart2Find = _context.Carts.Find(cartToUpdate); //try to find the respective cart
    if(Cart2Find == null)
    {
      throw new CartNotFoundException("Cart with this ID does not exist");
    }

    Item? Item2Find = _context.Items.AsNoTracking().Where(Item => (Item.CartFk == cartToUpdate) && (Item.ProductIdFk == itemToAdd.ProductIdFk)).FirstOrDefault(); //try to look for the item

    if(Item2Find == null)
    {
      _context.Add(itemToAdd);
      _context.SaveChanges(); //persist the change
      _context.ChangeTracker.Clear(); //clear the tracker for the next person
      return Cart2Find;
    }
    Item2Find.Quantity = itemToAdd.Quantity;
    _context.SaveChanges(); //persist the change
    _context.ChangeTracker.Clear(); //clear the tracker for the next person
    return Cart2Find;
  }

  /// <inheritdoc />
  public bool ConfirmPurchase(Cart cartToPurchase)
  {
    Cart? Cart2Find = _context.Carts.Find(cartToPurchase.CartId); //try to find the respective cart
    if(Cart2Find == null)
    {
      throw new CartNotFoundException("Cart with this ID does not exist");
    }
    Cart2Find.PurchaseTime = cartToPurchase.PurchaseTime;
    _context.SaveChanges(); //persist the change
    _context.ChangeTracker.Clear(); //clear the tracker for the next person
    return true; //this method cannot return false
  }


  /// <inheritdoc />
  public bool DeleteCart(int cartId2Delete)
  {
    Cart? Cart2Find = _context.Carts.Find(cartId2Delete); //try to find the respective cart
    if(Cart2Find == null)
    {
      throw new CartNotFoundException("Cart with this ID does not exist");
    }
    _context.Remove(Cart2Find);
    _context.SaveChanges(); //persist the change
    _context.ChangeTracker.Clear(); //clear the tracker for the next person
    return true;
  }

  /// <inheritdoc />
  public Cart findCartByCartID(int cartID2Find)
  {
    return _context.Carts.Find(cartID2Find) ?? throw new CartNotFoundException("Please double check your Cart ID");
  }

  /// <inheritdoc />
  public List<Cart> findCartsByUserID(int userID2Find)
  {
    return _context.Carts.AsNoTracking().Where(Cart => Cart.UserIdFk == userID2Find).ToList() ?? throw new UserNotFoundException("This person is a saint");
  }

  /// <inheritdoc />
  public Cart UpdateBillingAddress(Cart UpdatedBillingAddressCart)
  {
    Cart? Cart2Find = _context.Carts.Find(UpdatedBillingAddressCart.CartId); //try to find the respective cart
    if(Cart2Find == null)
    {
      throw new CartNotFoundException("Cart with this ID does not exist");
    }
    Cart2Find.BillingAddressIdFk = UpdatedBillingAddressCart.BillingAddressIdFk;
    _context.SaveChanges(); //persist the change
    _context.ChangeTracker.Clear(); //clear the tracker for the next person
    return Cart2Find;
  }

  /// <inheritdoc />
  public Cart UpdateShippingAddress(Cart UpdateShipAddressCart)
  {
    Cart? Cart2Find = _context.Carts.Find(UpdateShipAddressCart.CartId); //try to find the respective cart
    if(Cart2Find == null)
    {
      throw new CartNotFoundException("Cart with this ID does not exist");
    }
    Cart2Find.BillingAddressIdFk = UpdateShipAddressCart.ShippingAddressIdFk;
    _context.SaveChanges(); //persist the change
    _context.ChangeTracker.Clear(); //clear the tracker for the next person
    return Cart2Find;
  }
}