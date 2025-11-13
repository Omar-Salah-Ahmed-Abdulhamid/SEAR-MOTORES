namespace Cars_Auto.Models
{
    public class Categoriey:BaseModel
    {
		public ICollection<Car> cars { get; set; } = new List<Car>();

		//SUV, Sedan, Hatchback,Crosover 

	}
}
