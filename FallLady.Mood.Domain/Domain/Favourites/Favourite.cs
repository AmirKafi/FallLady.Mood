using FallLady.Mood.Domain.Domain.Blogs;
using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Domain.Domain.Teachers;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Favourites
{
    public class Favourite:EntityId<int>
    {

        #region Constructor

        public Favourite(string userId,FormEnum disclaimer,int? courseId,int? teacherId,int? blogId)
        {
            this.UserId = userId;
            this.Disclaimer = disclaimer;
            this.CourseId = courseId;
            this.TeacherId = teacherId;
            this.BlogId = blogId;
        }

        #endregion

        public string UserId { get; private set; }
        public User User { get; private set; }

        public FormEnum Disclaimer { get;private set; }

        public int? CourseId { get; private set; }
        public Course? Course { get; private set; }

        public int? TeacherId { get; private set; }
        public Teacher? Teacher { get; private set; }

        public int? BlogId { get; private set; }
        public Blog? Blog { get; private set; }
    }
}
