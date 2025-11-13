using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cars_Auto.Services
{
	public interface ICatogryiesServices
	{
		IEnumerable<SelectListItem> GetSelectLists();
	}
}
