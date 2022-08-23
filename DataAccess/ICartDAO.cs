using DataAccess.Entities;

/// <summary>
/// 
/// </summary>
public interface ICartDAO {

    /// <summary>
    /// Create a cart object.
    /// </summary>
    /// <param name="cartToCreate">The cart we want to create.</param>
    /// <returns>Returns true if cart is created, if not false.</returns>
    public bool CreateCart(Cart cartToCreate);

    /// <summary>
    /// Updates an existing cart object's billing address.
    /// </summary>
    /// <param name="UpdatedBillingAddresCart">Accepts a cart with an updated billing address.</param>
    /// <returns>Returns the Cart with its updated billing address. </returns>
    public Cart UpdateBillingAddres(Cart UpdatedBillingAddresCart); 

    /// <summary>
    /// Updates an existing cart object's shipping address.
    /// </summary>
    /// <param name="UpdateShipAddressCart">Accepts a cart with an updated shippping address</param>
    /// <returns>Returns the Cart with its updated shipping address</returns>
    public Cart UpdateShippingAddress(Cart UpdateShipAddressCart);

    /// <summary>
    /// Deletes a cart with the matching cart object.
    /// </summary>
    /// <param name="cartToDelete">The cart to delete</param>
    /// <returns>Return true if the cart deleted in db, if not false.</returns>
    public bool DeleteCart(Cart cartToDelete);

    /// <summary>
    /// adds/removes a SPECIFIC amount of items in/to cart 
    /// </summary>
    /// <param name="quantity"></param>
    /// <param name="itemToAdd"></param>
    /// <returns></returns>
    public Cart AdjustItems(int quantity, Item itemToAdd);

    /// <summary>
    /// updates the cart's  date to reflect when cart was purchased
    /// </summary>
    /// <param name="cartToPurchase"></param>
    /// <returns></returns>
    public bool ConfirmPurchase(Cart cartToPurchase); 


}