namespace FallLady.Mood.Application.Contract.Dto.Teacher
{
    public class TeacherListDto:BaseDtoListDto<int>
    {
        public string FullName { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public int Count { get; set; }
    }
}
