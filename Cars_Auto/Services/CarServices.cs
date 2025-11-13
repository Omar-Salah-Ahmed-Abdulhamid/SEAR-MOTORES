using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cars_Auto.Services
{
	public class CarServices : ICarServices
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _imagepath;



		public CarServices(AppDbContext context,
			IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
			_imagepath = $"{webHostEnvironment.WebRootPath}{FileSiting.ImagePath}";
		}
		// get all car in home page starrt =>
		public IEnumerable<Car> Getall()
		{
			return _context.Cars
				.Include(g => g.Categoriey)
				.Include(c => c.Images)
				.ToList();
		}
		// end get all=>.

		public Car? GetbyId(int id)
		{

			return _context.Cars
		   .Include(c => c.Categoriey)
		   .Include(c => c.Images)
		   .AsNoTracking()
		   .SingleOrDefault(c => c.Id == id);

		}
        // create a new car  start =>	

        

        public async Task create(CreatCarFromVM model)
		{
			//cover
			var coverName = await SaveCover(model.cover);
			Car car = new()
			{
				Name = model.Name,
				Description = model.Description,
				BrandName = model.BrandName,
				CategorieyId = model.CategorieyId,
				cover = coverName,
				Country = model.Country,
				Price = model.Price,

			};
			_context.Add(car);
			await _context.SaveChangesAsync();
			if (model.Images is not null && model.Images.Any())
			{
				var Galery = await SaveImages(model.Images, car.Id);
				_context.AddRange(Galery);
				await _context.SaveChangesAsync();
			}

			await _context.SaveChangesAsync();

		}

		// 		// end create=>>>
		//start update=>>

		public async Task<Car?> update(UpdateFromVM model)
		{
			var car = _context.Cars.Find(model.id);
			if (car is null)
			{
				return null;
			}
			var hasnewcover = model.cover is not null;
			var oldcover = car.cover;
			car.Name = model.Name;
			car.Description = model.Description;
			car.BrandName = model.BrandName;
			car.CategorieyId = model.CategorieyId;
			car.Price = model.Price;
			car.Country = model.Country;
			//galery update
			if (model.Images is not null && model.Images.Any())
			{
				var Galery = await SaveImages(model.Images, car.Id);
				_context.AddRange(Galery);
			}
			//end
			if (hasnewcover)
			{
				car.cover = await SaveCover(model.cover!);
			}
			var effectedRows = await _context.SaveChangesAsync();


			if (effectedRows > 0)
			{
				if (hasnewcover)
				{
					var cover = Path.Combine(_imagepath, oldcover);
					File.Delete(cover);
				}
				return car;
			}
			else
			{
				var cover = Path.Combine(_imagepath, car.cover);
				File.Delete(cover);
				return null;
			}


		}
		private async Task<string> SaveCover(IFormFile cover)
		{
			var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
			var path = Path.Combine(_imagepath, coverName);
			using var streem = File.Create(path);
			await cover.CopyToAsync(streem);
			return coverName;
		}

		// save images car star =>
		private async Task<List<CarImage>> SaveImages(List<IFormFile> images, int carId)
		{
			var carImages = new List<CarImage>();

			foreach (var img in images)
			{
				var fileName = $"{Guid.NewGuid()}{Path.GetExtension(img.FileName)}";
				var path = Path.Combine(_imagepath, fileName);

				using var streem = File.Create(path);
				await img.CopyToAsync(streem);
				carImages.Add(new CarImage
				{
					carid = carId,
					ImageUrl = fileName,
				});
			}

			return carImages;
		}

		// save images end=>

		public bool delete(int id)
		{
			var isDeleted = false;

			var car = _context.Cars.
				Include(c => c.Images).
				SingleOrDefault(c => c.Id == id);

			if (car is null)
			{
				return isDeleted;
			}
			_context.Cars.Remove(car);
			var effectedRows = _context.SaveChanges();
			if (effectedRows > 0)
			{
				isDeleted = true;
				var covername = Path.Combine(_imagepath, car.cover);
				File.Delete(covername);

				foreach (var img in car.Images)
				{
					var imagename = Path.Combine(_imagepath, img.ImageUrl);
					File.Delete(imagename);
				}
			}
			return isDeleted;

		}

	}
}
