using FallLady.Mood.Application.Contract.Dto.Blogs;
using FallLady.Mood.Application.Contract.Interfaces.Blogs;
using FallLady.Mood.Application.Contract.Interfaces.Favourites;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Controllers.Base;
using FallLady.Mood.Domain.Enums;
using FallLady.Mood.Framework.Core.Enum;
using Microsoft.AspNetCore.Mvc;

namespace FallLady.Mood.Controllers
{
    public class BlogController : BaseController
    {
        #region Constructor
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;
        private readonly IFavouriteService _favouriteService;

        public BlogController(IBlogService blogService, IFavouriteService favouriteService, IUserService userService)
        {
            _blogService = blogService;
            _favouriteService = favouriteService;
            _userService = userService;
        }
        #endregion

        [Route("/Blogs")]
        public async Task<ActionResult> Blogs(BlogDto dto)
        {
            dto.limit = 100;
            dto.offset = 0;

            var blogs = await _blogService.LoadBlogs(dto).ConfigureAwait(false);
            blogs.Data.ForEach(x => x.PicturePath = GetFileUrl(x.Picture, FileFoldersEnum.Blog));

            return View("Index", blogs.Data);
        }

        [Route("/BlogDetails")]
        public async Task<ActionResult> BlogDetails(int blogId)
        {
            var blog = await _blogService.GetBlogDetails(blogId).ConfigureAwait(false);
            var model = blog.Data;

            model.PicturePath = GetFileUrl(model.Picture, FileFoldersEnum.Blog);

            var userId = await _userService.GetUserId(User).ConfigureAwait(false);

            var isFavourite = await _favouriteService.IsFavourite(userId.Data, FormEnum.Blog, blogId);

            model.IsCurrentUserFavourite = isFavourite.Data;

            return View("BlogDetails", blog.Data);
        }
    }
}
