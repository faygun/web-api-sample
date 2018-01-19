using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaCounter.Global.Models.ServiceModels;

namespace TeaCounter.Business.Interfaces
{
    public interface IProductService
    {
        List<ProductResponseModel> GetProduct(long providerId);
    }
}
