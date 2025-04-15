using Demo.DAL._Data.Context;
using GameZone.Helper.Services.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Helper.Services
{
    public class CreateServices : ICreateServices
    {
        private readonly StoreContext _storeContext;

        public CreateServices(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<SelectListItem> GetSelectListCategories()
        {
            return _storeContext.categories.Select(
                c=>new SelectListItem { Value=c.Id.ToString(),Text=c.Name } 
                )
                .OrderBy(c=>c.Text)
                .ToList();
     
        }

        public IEnumerable<SelectListItem> GetSelectListDevices()
        {
            return _storeContext.devices.Select(
                c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }
                )
                .OrderBy(c => c.Text)
                .ToList();
        }
    }
}
