using Cars_Auto.Models;

namespace Cars_Auto.Services
{
	public interface ICarServices
	{

		IEnumerable<Car> Getall();
		Car ?GetbyId(int id);
		
        Task create(CreatCarFromVM car);
		 Task<Car?> update(UpdateFromVM model);
		bool delete(int id);
	}
}
