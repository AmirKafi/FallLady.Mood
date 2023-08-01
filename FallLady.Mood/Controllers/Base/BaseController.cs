using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FallLady.Mood.Controllers.Base
{
    public class BaseController : Controller
    {

        protected string GetEnumDisplayValue(Enum enumName)
        {
            var type = enumName.GetType();
            var field = type.GetField(enumName.ToString());
            var display = ((System.ComponentModel.DataAnnotations.DisplayAttribute[])field?.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false))?.FirstOrDefault();
            return display != null
                ? display.GetName()
                : enumName.ToString();
        }

        protected List<SelectListItem> EnumToList(Type enumType, Enum selectedItem, bool orderBy = true, Enum[] ignore = null)
        {
            var items = new List<SelectListItem>();
            if (enumType == null)
                return items;

            var values = Enum.GetValues(enumType);
            items.AddRange(from Enum item in values
                           where ignore == null || !ignore.Contains(item)
                           select new SelectListItem
                           {
                               Value = item.ToString(),
                               Text = GetEnumDisplayValue(item),
                               Selected = selectedItem != null && item.ToString() == selectedItem.ToString()
                           });
            return orderBy
                ? items.OrderBy(item => item.Text)
                    .ToList()
                : items.ToList();
        }
    }
}
