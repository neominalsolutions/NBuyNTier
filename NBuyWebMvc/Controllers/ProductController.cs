using Microsoft.AspNetCore.Mvc;
using NBuyApplication.Dtos;
using NBuyApplication.Services;
using NBuyCore.Services;
using NBuyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBuyWebMvc.Controllers
{
    public class ProductController : Controller
    {
        private ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDto model)
        {
            // presentation kmatmanı application katmanına gelen iş isteğini yönlendirir. amacı rouyting yön lendirmedir.
            _productService.CreateCommand(model);

            return View();
        }
    }
}
