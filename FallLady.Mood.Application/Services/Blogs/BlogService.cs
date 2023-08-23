using FallLady.Mood.Application.Contract.Dto.Blogs;
using FallLady.Mood.Application.Contract.Interfaces.Blogs;
using FallLady.Mood.Domain.Domain.Categories;
using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FallLady.Mood.Domain.Domain.Blogs;
using FallLady.Mood.Application.Contract.Mappers.Blogs;
using Microsoft.EntityFrameworkCore;

namespace FallLady.Mood.Application.Services.Blogs
{
    public class BlogService : IBlogService
    {
        #region Constructor
        private readonly IBlogRepository _repository;
        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        #endregion

        public async Task<ServiceResponse<List<BlogListDto>>> LoadBlogs(BlogDto dto)
        {
            var result = new ServiceResponse<List<BlogListDto>>();
            try
            {
                var data = _repository.GetQuerable()
                                      .Include(x=> x.Author)
                                      .Skip(dto.limit * dto.offset)
                                      .Take(dto.limit);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<List<BlogListDto>>> LoadBlogs()
        {
            var result = new ServiceResponse<List<BlogListDto>>();
            try
            {
                var data = _repository.GetQuerable()
                                      .Include(x => x.Author);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddBlog(BlogCreateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                await _repository.Add(dto.ToModel());
                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<BlogUpdateDto>> GetBlog(int blogId)
        {
            var result = new ServiceResponse<BlogUpdateDto>();
            try
            {
                var data = await _repository.Get(blogId);
                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdateBlog(BlogUpdateDto dto)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var blog = await _repository.Get(dto.Id);
                blog.Update(dto.Title,
                            dto.TextBody,
                            dto.Picture);

                await _repository.Update(blog);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> Delete(int blogId)
        {
            var result = new ServiceResponse<bool>();
            try
            {
                var blog = await _repository.GetById(blogId);
                await _repository.Delete(blog);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex.Message);
            }

            return result;
        }
    }
}
