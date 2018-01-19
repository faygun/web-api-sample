using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaCounter.Business.Interfaces;

namespace TeaCounter.Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var asd = _productService.GetProduct(1);
            return View();
        }
    }
}