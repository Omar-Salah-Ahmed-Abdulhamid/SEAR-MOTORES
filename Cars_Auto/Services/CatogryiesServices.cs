using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cars_Auto.Services
{

    public class CatogryiesServices : ICatogryiesServices
    {
        private readonly AppDbContext _context;

        public CatogryiesServices(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectLists()
        {
            return _context.Categories.
                    Select(c => new SelectListItem
                    { Value = c.Id.ToString(), Text = c.Name })
                    .OrderBy(c => c.Text)
                    //.AsNoTracking()
                    .ToList();
        }
    }
}
