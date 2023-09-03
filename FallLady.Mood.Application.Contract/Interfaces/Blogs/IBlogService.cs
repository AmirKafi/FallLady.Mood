using FallLady.Mood.Application.Contract.Dto.Blogs;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Interfaces.Blogs
{
    public interface IBlogService
    {
        Task<ServiceResponse<List<BlogListDto>>> LoadBlogs(BlogDto dto);
        Task<ServiceResponse<List<BlogListDto>>> LoadBlogs();
        Task<ServiceResponse<BlogDetailDto>> GetBlogDetails(int blogId);
        Task<ServiceResponse<bool>> AddBlog(BlogCreateDto dto);
        Task<ServiceResponse<BlogUpdateDto>> GetBlog(int blogId);
        Task<ServiceResponse<bool>> UpdateBlog(BlogUpdateDto dto);
        Task<ServiceResponse<bool>> Delete(int blogId);
    }
}
