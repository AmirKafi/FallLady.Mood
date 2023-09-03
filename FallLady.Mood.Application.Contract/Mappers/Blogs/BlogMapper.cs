using FallLady.Mood.Application.Contract.Dto.Blogs;
using FallLady.Mood.Domain.Domain.Blogs;
using FallLady.Mood.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers.Blogs
{
    public static class BlogMapper
    {
        public static Blog ToModel(this BlogCreateDto dto)
        {
            return new Blog(dto.Title,
                            dto.TextBody,
                            dto.Picture,
                            dto.AuthorId);
        }

        public static List<BlogListDto> ToDto(this IEnumerable<Blog>? model)
        {
            if (model is null)
                return new List<BlogListDto>();

            return model.Select(x => new BlogListDto()
            {
                Id = x.Id,
                Title = x.Title,
                TextBody = x.TextBody,
                Picture= x.Picture,
                CreatedOn = x.CreatedOn,
                AuthorName = x.Author.FirstName + " " + x.Author.LastName,
            }).ToList();
        }

        public static BlogUpdateDto ToDto(this Blog model)
        {
            return new BlogUpdateDto()
            {
                Id = model.Id,
                Title = model.Title,
                TextBody = model.TextBody,
                Picture = model.Picture
            };
        }

        public static BlogDetailDto ToDetailDto(this Blog model)
        {
            return new BlogDetailDto()
            {
                Id = model.Id,
                Title = model.Title,
                TextBody = model.TextBody,
                Picture = model.Picture,
                AuthorName = model.Author.FirstName + " " + model.Author.LastName
            };
        }
    }
}
