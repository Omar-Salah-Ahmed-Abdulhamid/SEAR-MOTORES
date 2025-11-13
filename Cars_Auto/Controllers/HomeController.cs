using Cars_Auto.Models;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cars_Auto.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICarServices _carServices;

		public HomeController( ICarServices carServices)
		{
			
			_carServices = carServices;
		}

		public IActionResult Index()
		{
			var cars=_carServices.Getall();
			return View(cars);
		}

		//public IActionResult Privacy()
		//{
		//	return View();
		//}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
