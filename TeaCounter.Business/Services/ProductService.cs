using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaCounter.Business.Interfaces;
using TeaCounter.Data.Interfaces;
using TeaCounter.Global.Models.ServiceModels;

namespace TeaCounter.Business.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductData _dataProduct;

        public ProductService(IProductData dataProduct)
        {
            _dataProduct = dataProduct;
        }


        public List<ProductResponseModel> GetProduct(long providerId)
        {
            return _dataProduct.GetProduct(providerId);
        }
    }
}
