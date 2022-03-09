using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepo;
        private readonly IRepository<Product> _productRepo;

        public BasketService(IRepository<Basket> basketRepo, IRepository<Product> productRepo)
        {
            _basketRepo = basketRepo;
            _productRepo = productRepo;
        }

        public async Task<Basket> AddItemToBasketAsync(int basketId, int productId, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentException("Quantity must be grater than zero");
            var product = await _productRepo.GetByIdAsync(productId);
            if (product == null) 
                throw new ArgumentException($"Product with the id {productId} cannot be found.");
            var spec = new BasketWithItemsSpecification(basketId);
            var basket = await _basketRepo.FirstODefaultAsync(spec);
            if (basket == null) 
                throw new ArgumentException($"Basket with the id {basketId} cannot be found.");

            var basketItem = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            if (basketItem == null)
            { 
                basketItem = new BasketItem() { BasketId = basketId, ProductId = productId, Quantity = quantity, Product = product};
                basket.Items.Add(basketItem);
            }
            else
                basketItem.Quantity += quantity;
            await _basketRepo.UpdateAsync(basket);
            
            return basket;
        }
    }
}
