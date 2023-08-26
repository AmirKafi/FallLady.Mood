namespace FallLady.Mood.Application.Contract.Dto.Category
{
    public class CategoryListDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public int Count { get; set; }
    }
}
