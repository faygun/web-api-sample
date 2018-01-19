using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaCounter.Data.Interfaces;
using TeaCounter.Global.Models.ServiceModels;

namespace TeaCounter.Data.Models
{
    public class ProductData:IProductData
    {
        public ProductData()
        {
            //TODO:Buraya servis endpoint felen gelecek...
        }

        public List<ProductResponseModel> GetProduct(long providerId)
        {
            return new List<ProductResponseModel>
            {
                new ProductResponseModel(){
                    Count = 0,
                    Name = "Çay",
                    Price = 1.5
                },
                new ProductResponseModel(){
                    Count = 0,
                    Name = "Kahve",
                    Price = 5
                },
                new ProductResponseModel(){
                    Count = 0,
                    Name = "Oralet",
                    Price = 1.5
                }
            };
        }
    }
}
