
using Cars_Auto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cars_Auto.Controllers
{
    public class CarsController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ICatogryiesServices _catogryiesServices;
        private readonly ICarServices _carServices;
		public CarsController(AppDbContext context, ICatogryiesServices catogryiesServices, ICarServices carServices)
		{
			_context = context;
			this._catogryiesServices = catogryiesServices;
			_carServices = carServices;
		}
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Admin") return Unauthorized();

            var cars = _carServices.Getall();
            return View(cars);
        }

        [HttpGet]
        
        public IActionResult create()
        {
            CreatCarFromVM ViewModel = new()
            {
                Catogryies = _catogryiesServices.GetSelectLists()
                

            };
            return View(ViewModel);
        }
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> create(CreatCarFromVM model)
        {
			
			
			if (!ModelState.IsValid)
            {
                model.Catogryies = _catogryiesServices.GetSelectLists();
                

				return View(model); 
            }



            await _carServices.create(model);

            return RedirectToAction(nameof(Index));
        }
//creat end=>

        public IActionResult Detalies(int id)
        {
            var car=_carServices.GetbyId(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);  
        }
		
		public IActionResult update(int id)
        {
            var car = _carServices.GetbyId(id);
            if (car == null)
            {
                return NotFound();
            }
            UpdateFromVM ViewModel = new()
            {
				id = id,
                Name=car.Name,
                Description=car.Description,
                CategorieyId=car.CategorieyId,
                BrandName=car.BrandName,
				Catogryies = _catogryiesServices.GetSelectLists(),
                Price=car.Price,
                Country=car.Country,

				CurrentCover=car.cover,

			};

            return View(ViewModel);
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> update(UpdateFromVM model)
		{
			if (!ModelState.IsValid)
			{
				model.Catogryies = _catogryiesServices.GetSelectLists();

				return View(model);
			}
            var car =await _carServices.update(model);
            if (car is null)
            {
               return BadRequest();
            }
			return RedirectToAction(nameof(Index));



		}
        [HttpDelete]
		public IActionResult Delete(int id)
        {
			var isdeleted=_carServices.delete(id);
            return isdeleted?Ok():BadRequest();
        }
    }
}

