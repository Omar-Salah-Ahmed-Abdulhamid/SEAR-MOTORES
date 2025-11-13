using Cars_Auto.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Auto.Controllers
{
	public class PurchaseController : Controller
	{
		private readonly AppDbContext _context;

		public PurchaseController(AppDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult Buy(int carId)
		{
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Auth");
            var car = _context.Cars.Find(carId);
			if (car == null) return NotFound();

            var purchase = new Purchase
            {
                UserId =userId,
                CarId = car.Id,
                FinalPrice = car.Price,
                PurchaseDate = DateTime.Now
            };


            _context.Purchases.Add(purchase);
			_context.SaveChanges();

			return RedirectToAction("MyPurchases");
		}

        public IActionResult MyPurchases()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Auth");

            var purchases = _context.Purchases
                .Where(p => p.UserId == userId)
                .Select(p => new PurchaseVM
                {
                    CarId = p.Car.Id,
                    Id=p.Id,
                    BuyerName = p.User.Name,
                    CarName = p.Car.Name,
                    BrandName = p.Car.BrandName,
                    Cover = p.Car.cover,
                    CategoryName = p.Car.Categoriey.Name,
                    Country = p.Car.Country,
                    FinalPrice = p.FinalPrice,
                    PurchaseDate = p.PurchaseDate
                })
                .ToList();

            return View(purchases);
        }

        public IActionResult AllPurchases()
        {
            var purchases = _context.Purchases
                .Include(p => p.Car)
                .Include(p => p.User)
                .Select(p => new PurchaseVM
                {
                    Id = p.Id,
                    BuyerName = p.User.Name,
                    CarName = p.Car.Name,
                    BrandName = p.Car.BrandName,
                    CategoryName = p.Car.Categoriey.Name,
                    Country = p.Car.Country,
                    FinalPrice = p.FinalPrice,
                    PurchaseDate = p.PurchaseDate
                })
                .ToList();

            return View(purchases);
        }


        [HttpDelete]
		public IActionResult Delete(int id)
		{
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return Unauthorized();

            var purchase = _context.Purchases.FirstOrDefault(p => p.Id == id && p.UserId == userId);
			if (purchase == null) return NotFound();

			_context.Purchases.Remove(purchase);
			_context.SaveChanges();

			return Ok();
		}



	}
}
