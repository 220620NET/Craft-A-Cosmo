using DataAccess.Entities;
namespace DataAccess.Interface;

/// <summary>
/// Manages the cart interactions
/// </summary>
public interface ICartDAO 
{
    /// <summary>
    /// Create a cart object.
    /// </summary>
    /// <param name="cartToCreate">The cart we want to create.</param>
    /// <returns>Returns true if cart is created, if not false.</returns>
    public bool CreateCart(Cart cartToCreate);

    /// <summary>
    /// Updates an existing cart object's billing address.
    /// </summary>
    /// <param name="UpdatedBillingAddressCart">Accepts a cart with an updated billing address.</param>
    /// <returns>Returns the Cart with its updated billing address. </returns>
    public Cart UpdateBillingAddress(Cart UpdatedBillingAddressCart); 

    /// <summary>
    /// Updates an existing cart object's shipping address.
    /// </summary>
    /// <param name="UpdateShipAddressCart">Accepts a cart with an updated shipping address</param>
    /// <returns>Returns the Cart with its updated shipping address</returns>
    public Cart UpdateShippingAddress(Cart UpdateShipAddressCart);

    /// <summary>
    /// Deletes a cart with the corresponding cart id.
    /// </summary>
    /// <param name="cartId2Delete">The cart id to delete</param>
    /// <returns>Return true if the cart deleted in db, if not false.</returns>
    public bool DeleteCart(int cartId2Delete);

    /// <summary>
    /// Adds/removes a SPECIFIC amount of items in/to cart.
    /// </summary>
    /// <param name="cartId2Update">The number of items to be added or subtracted from existing</param>
    /// <param name="itemToAdd">The item to be added/removed from the cart</param>
    /// <returns>The adjusted cart object</returns>
    public Cart AdjustItems(int cartId2Update, Item itemToAdd);

    /// <summary>
    /// Updates the cart's date to reflect when cart was purchased.
    /// </summary>
    /// <param name="cartToPurchase">The cart the needs to have their date modified</param>
    /// <returns>True of operation is successful, false otherwise</returns>
    public bool ConfirmPurchase(Cart cartToPurchase); 

    /// <summary>
    /// Looks into the database for a cart with the given ID.
    /// </summary>
    /// <param name="cartID2Find">The cart ID you are trying to find</param>
    /// <returns>The cart if found</returns>
    /// <exception cref="CartNotFoundException">Occurs if no cart matches the given cart ID object</exception>
    public Cart findCartByCartID(int cartID2Find); 

    /// <summary>
    /// Looks for a cart that is associated to the given userID.
    /// </summary>
    /// <param name="userID2Find">The user ID you are trying to use</param>
    /// <returns>The cart if found</returns>
    /// <exception cref="CartNotFoundException">Occurs if no cart matches the given cart ID object</exception>
    public List<Cart> findCartsByUserID(int userID2Find);
}