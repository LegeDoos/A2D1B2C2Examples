﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using Northwind.Shared;
using System.Diagnostics;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindDataContext db;

        public HomeController(ILogger<HomeController> logger, NorthwindDataContext injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        [ResponseCache(Duration = 100, Location = ResponseCacheLocation.Client)]
        public IActionResult Index()
        {
            HomeIndexViewModel model = new(Random.Shared.Next(1, 1001), db.Categories.ToList(), db.Products.ToList());
            return View(model);
        }

        public IActionResult ProductDetail(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("You have to pass a product id!");
            }

            Product? model = db.Products.SingleOrDefault(p => p.ProductId == id);

            if (model is null)
            {
                return NotFound($"Product {id} not found");
            }

            return View(model);
        }


        [Authorize(Roles = "Administrators")]
        [Route("private")]
        public IActionResult Privacy()
        {
            _logger.LogError("This is a serious error (not!)");
            _logger.LogWarning("Warning 1... 2...");
            _logger.LogCritical("Einde oefening!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Modelbinding example: page with a form to submit
        /// </summary>
        /// <returns></returns>
        public IActionResult ModelBinding()
        {
            return View();
        }

        /// <summary>
        /// Page to show the model bound thing
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            HomeModelBindingViewModel model = new(
                thing, 
                !ModelState.IsValid, 
                ModelState.Values.SelectMany(state => state.Errors).Select(error => error.ErrorMessage)
            );

            return View(model);
        }


        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if (!price.HasValue)
            {
                return BadRequest("You must pass a product price!");
            }
            IEnumerable<Product> model = db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.UnitPrice > price);

            if (!model.Any())
            {
                return NotFound($"No products found that cost more than {price:C}.");
            }

            ViewData["MaxPrice"] = price.Value.ToString("C");
            return View(model);
        }
    }
}