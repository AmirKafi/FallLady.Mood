using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Tags
{
    public class Tag : EntityId<int>
    {
        public Tag(string title, TagTypesEnum tagType)
        {
            this.Title = title;
            this.TagType = tagType;
        }
        public string Title { get; set; }
        public TagTypesEnum TagType { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
