using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Helper.Services.Interface
{
    public interface ICreateServices
    {
        IEnumerable<SelectListItem> GetSelectListCategories();
        IEnumerable<SelectListItem> GetSelectListDevices();
    }
}
