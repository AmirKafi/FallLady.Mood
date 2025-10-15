using System.ComponentModel.DataAnnotations;

namespace FallLady.Mood.Application.Contract.Dto.Teacher
{
    public class TeacherUpdateDto
    {
        public int Id { get; set; }

        [Display(Name = "نام و نام خانوادگی مدرس")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public string FullName { get; set; }
    }
}
