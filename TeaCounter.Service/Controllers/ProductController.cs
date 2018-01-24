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
using Swagger.Net.Annotations;

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
        /// <summary>
        /// GetProduct method id is productId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet]
        [SwaggerOperation("GetProduct")]
        public IHttpActionResult GetProduct(int id)
        {
            List<ProductResponseModel> products = _productService.GetProduct(1);
            return Ok(products);
        }
        /// <summary>
        /// AllProduct method
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet]
        public IHttpActionResult AllProduct()
        {
            List<ProductResponseModel> products = _productService.GetProduct(1);
            return Ok(products);
        }

        /// <summary>
        /// AddProduct method name is product name and price is product price
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpPost]
        public IHttpActionResult AddProduct (string name, double price)
        {
            return Ok(true);
        }
    }
}
