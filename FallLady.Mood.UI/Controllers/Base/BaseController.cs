namespace FallLady.Mood.UI.Controllers.Base
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using System.Configuration;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;

    public class BaseController : Controller
    {
        protected string ShareUrl => ConfigurationManager.AppSettings["ShareUrl"];

        protected string GetEnumDisplayValue(Enum enumName)
        {
            var type = enumName.GetType();
            var field = type.GetField(enumName.ToString());
            var display = ((DisplayAttribute[])field?.GetCustomAttributes(typeof(DisplayAttribute), false))?.FirstOrDefault();
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

        protected string GetErrorMessages()
        {
            return string.Join("<br/>",
                ModelState.Values.Where(state => state.Errors.Count > 0)
                    .Select(state => string.Join("<br/>",
                        state.Errors
                            .Where(error => !string.IsNullOrEmpty(error.ErrorMessage))
                            .Select(error => error.ErrorMessage)
                            .ToList()))
                    .ToList());
        }
    }
}
