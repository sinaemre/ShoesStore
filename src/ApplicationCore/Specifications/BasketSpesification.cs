using ApplicationCore.Entities;
using Ardalis.Specification;
using System.Linq;

namespace ApplicationCore.Specifications
{
    public class BasketSpesification : Specification<Basket>
    {
        public BasketSpesification(string buyerId)
        {
            Query.Where(x => x.BuyerId == buyerId);
        }
    }
}
