namespace FallLady.Mood.Application.Contract.Dto.Blogs
{
    public class BlogListDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string TextBody { get; set; }

        public string Picture { get; set; }
        public string PicturePath { get; set; }

        public string ShortDescription { get; set; }
    }
}
