// using CustomExceptions;
// using DataAccess.Entities;
// using DataAccess.Interface;
// using Services;
// using Moq;

// namespace Tests;

// public class CartTests
// {
//     [Fact]
//     public void CreateCartShouldReturnCart()
//     {
//         var MockedRepo = new Mock<ICartDAO>();

//         Cart newCart = new Cart()
//         {
//             CartId = 1,
//             ShippingAddressFk = 1,
//             BillingAddressFk = 1,
//             UserIdFk = 1,
//             PurchaseTime = DateTime.Now,
//             ShippingNote = ""
//         };

//         MockedRepo.Setup(repo => repo.CreateCart(newCart)).Returns(newCart);
//         //int UserIdFk, int ShippingAddressFk, int BillingAddressFk

//         CartServices service = new CartServices(MockedRepo.Object);

//         int UserIdFk = 1;
//         int ShippingAddressFk = 1;
//         int BillingAddressFk = 1;

//     }
// }