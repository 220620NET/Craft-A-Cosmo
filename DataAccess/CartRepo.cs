using DataAccess.Interface;
using DataAccess.Entities;
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
  public Cart AdjustItems(int cartToUpdate, Item itemToAdd)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc />
  public bool ConfirmPurchase(Cart cartToPurchase)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc />
  public bool CreateCart(Cart cartToCreate)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc />
  public bool DeleteCart(int cartId2Delete)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc />
  public Cart findCartByCartID(int cartID2Find)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc />
  public List<Cart> findCartsByUserID(int userID2Find)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc />
  public Cart UpdateBillingAddress(Cart UpdatedBillingAddressCart)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc />
  public Cart UpdateShippingAddress(Cart UpdateShipAddressCart)
  {
    throw new NotImplementedException();
  }
}