using DataAccess.Entities;
namespace Services;

public class CartServices
{
    /// <summary>
    /// Create a cart object.
    /// </summary>
    /// <param name="cartToCreate">The cart we want to create.</param>
    /// <returns>Returns true if cart is created, if not false.</returns>
    public bool CreateCart(Cart cartToCreate)
    {
        return false;
    }

    /// <summary>
    /// Updates an existing cart object's billing address.
    /// </summary>
    /// <param name="UpdatedBillingAddressCart">Accepts a cart with an updated billing address.</param>
    /// <returns>Returns the Cart with its updated billing address. </returns>
    public bool UpdateBillingAddress(Cart UpdatedBillingAddressCart)
    {
        return false;
    }
    
    /// <summary>
    /// Updates an existing cart object's shipping address.
    /// </summary>
    /// <param name="UpdateShipAddressCart">Accepts a cart with an updated shipping address</param>
    /// <returns>Returns the Cart with its updated shipping address</returns>
    public bool UpdateShippingAddress(Cart UpdateShipAddressCart)
    {
        return false;
    }

    /// <summary>
    /// Deletes a cart with the matching cart object.
    /// </summary>
    /// <param name="cartToDelete">The cart to delete</param>
    /// <returns>Return true if the cart deleted in db, if not false.</returns>
    public bool DeleteCart(Cart cartToDelete)
    {
        return false;
    }

    /// <summary>
    /// Adds/removes a SPECIFIC amount of items in/to cart.
    /// </summary>
    /// <param name="cartToUpdate">The number of items to be added or subtracted from existing</param>
    /// <param name="productToAdd">The product to be added/removed from the cart</param>
    /// <param name="Quantity">The amount of a particular product that shall be added </param>
    /// <returns>The adjusted cart object</returns>
    public bool AdjustItems(int cartID, Product productToAdd, int Quantity)
    {
        return false;
    }

    /// <summary>
    /// Updates the cart's date to reflect when cart was purchased.
    /// </summary>
    /// <param name="cartToPurchase">The cart the needs to have their date modified</param>
    /// <returns>True of operation is successful, false otherwise</returns>
    public bool ConfirmPurchase(Cart cartToPurchase)
    {
        return false;
    }

    /// <summary>
    /// Looks for a cart that is associated to the given userID.
    /// </summary>
    /// <param name="userID2Find">The user ID you are trying to use</param>
    /// <returns>The cart if found</returns>
    /// <exception cref="CartNotFoundException">Occurs if no cart matches the given cart ID object</exception>
    public bool findCartByUserID(int userID2Find)
    {
        return false;
    }
}