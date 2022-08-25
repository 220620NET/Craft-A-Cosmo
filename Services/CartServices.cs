using DataAccess.Entities;
using DataAccess.Interface;
namespace Services;

public class CartServices
{

    private readonly ICartDAO _cart;

    public CartServices(ICartDAO cartDAO)
    {
        _cart = cartDAO;
    }

    /// <summary>
    /// Create a cart object.
    /// </summary>
    /// <param name="UserIdFk">The user id who is creating the cart.</param>
    /// <param name="ShippingAddressFk">The fk of the shippping address.</param>
    /// <param name="BillingAddressFk">The fk of the billing address.</param>
    /// <returns>Returns true if cart is created, if not false.</returns>
    public Cart CreateCart(int UserIdFk, int ShippingAddressFk, int BillingAddressFk)
    {
        Cart cart = new Cart()
        {
            UserIdFk = UserIdFk,
            ShippingAddressIdFk = ShippingAddressFk,
            BillingAddressIdFk = BillingAddressFk,
        };

        try
        {
            _cart.CreateCart(cart);
            return cart;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates an existing cart object's billing address.
    /// </summary>
    /// <param name="UpdatedBillingAddressCart">Accepts a cart with an updated billing address.</param>
    /// <returns>Returns the Cart with its updated billing address. </returns>
    public Cart UpdateBillingAddress(int UpdatedBillingAddressFk, int CartId)
    {
        Cart cart2Update = _cart.findCartByCartID(CartId);
        cart2Update.BillingAddressIdFk = UpdatedBillingAddressFk;
        try
        {
            return _cart.UpdateBillingAddress(cart2Update);
        }
        catch
        {
            throw;
        }
    }
    
    /// <summary>
    /// Updates an existing cart object's shipping address.
    /// </summary>
    /// <param name="UpdateShipAddressCart">Accepts a cart with an updated shipping address</param>
    /// <returns>Returns the Cart with its updated shipping address</returns>
    public Cart UpdateShippingAddress(int UpdateShipAddressFk, int CartId)
    {
        Cart cart2Update = _cart.findCartByCartID(CartId);
        cart2Update.ShippingAddressIdFk = UpdateShipAddressFk;
        try
        {
            return _cart.UpdateShippingAddress(cart2Update);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Deletes a cart with the matching cart object.
    /// </summary>
    /// <param name="cartId2Delete">The cart to delete</param>
    /// <returns>Return true if the cart deleted in db, if not false.</returns>
    public bool DeleteCart(int CartId2Delete)
    {
        try
        {
            return _cart.DeleteCart(CartId2Delete);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Adds/removes a SPECIFIC amount of items in/to cart.
    /// </summary>
    /// <param name="cartToUpdate">The number of items to be added or subtracted from existing</param>
    /// <param name="ProductId">The product to be added/removed from the cart</param>
    /// <param name="Quantity">The amount of a particular product that shall be added </param>
    /// <returns>The adjusted cart object</returns>
    public Cart AdjustItems(int ProductId, int CartId, int Quantity)
    {
        Item Item2Adjust = new Item()
        {
            ProductIdFk = ProductId,
            CartFk = CartId,
            Quantity = Quantity
        };

        try
        {
            return _cart.AdjustItems(CartId, Item2Adjust);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Updates the cart's date to reflect when cart was purchased.
    /// </summary>
    /// <param name="cartToPurchase">The cart the needs to have their date modified</param>
    /// <returns>True of operation is successful, false otherwise</returns>
    public bool ConfirmPurchase(int CartIdToPurchase)
    {
        try
        {
            Cart ConfirmedCart = _cart.findCartByCartID(CartIdToPurchase);
            ConfirmedCart.PurchaseTime = DateTime.Now;
            return _cart.ConfirmPurchase(ConfirmedCart);
        }
        catch
        {
            throw;
        }
        
    }

    /// <summary>
    /// Looks for a cart that is associated to the given userID.
    /// </summary>
    /// <param name="userID2Find">The user ID you are trying to use</param>
    /// <returns>The cart if found</returns>
    /// <exception cref="CartNotFoundException">Occurs if no cart matches the given cart ID object</exception>
    public List<Cart> findCartsByUserID(int userID2Find)
    {
        try
        {
            return _cart.findCartsByUserID(userID2Find);
        }
        catch
        {
            throw;
        }
    }
}