using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TeaCounter.Business.Interfaces;
using TeaCounter.Global.Models.ServiceModels;

namespace TeaCounter.Service.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IHttpActionResult GetProduct()
        {
            List<ProductResponseModel> products = _productService.GetProduct(1);
            return Ok(products);
        }
    }
}
