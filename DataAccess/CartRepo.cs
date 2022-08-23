using DataAccess.Interface;
using DataAccess.Entities;


namespace DataAccess;

public class CartRepo : ICartDAO
{
  private readonly p3dbContext _context;
  
  public CartRepo(p3dbContext context)
  {
    _context = context;
  }

  public Cart AdjustItems(Cart cartToUpdate, Item itemToAdd)
  {
    throw new NotImplementedException();
  }

  public bool ConfirmPurchase(Cart cartToPurchase)
  {
    throw new NotImplementedException();
  }

  public bool CreateCart(Cart cartToCreate)
  {
    throw new NotImplementedException();
  }

  public bool DeleteCart(Cart cartToDelete)
  {
    throw new NotImplementedException();
  }

  public Cart findCartByCartID(int cartID2Find)
  {
    throw new NotImplementedException();
  }

  public Cart findCartByUserID(int userID2Find)
  {
    throw new NotImplementedException();
  }

  public Cart UpdateBillingAddress(Cart UpdatedBillingAddressCart)
  {
    throw new NotImplementedException();
  }

  public Cart UpdateShippingAddress(Cart UpdateShipAddressCart)
  {
    throw new NotImplementedException();
  }
}