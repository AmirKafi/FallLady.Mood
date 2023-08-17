using FallLady.Mood.Application.Contract.Dto.Category;
using FallLady.Mood.Domain.Domain.Categories;
using FallLady.Mood.Domain.Domain.Teachers;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers.Categories
{
    public static class CategoryMapper
    {
        public static Category ToModel(this CategoryCreateDto dto)
        {
            return new Category(dto.Title);
        }

        public static List<CategoryListDto> ToDto(this IEnumerable<Category>? model)
        {
            if (model is null)
                return new List<CategoryListDto>();

            return model.Select(x => new CategoryListDto()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }

        public static CategoryUpdateDto ToDto(this Category model)
        {
            return new CategoryUpdateDto()
            {
                Id = model.Id,
                Title = model.Title
            };
        }
        public static ComboModel ToComboModel(this Category model)
        {
            return new ComboModel()
            {
                Title = model.Title,
                Value = model.Id
            };
        }
    }
}
