using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Discounts
{
    public class Discount : EntityId<int>
    {
        public Discount(string code,
                            int precentage,
                            string? description,
                            string? specifiedUserId,
                            int? specifiedCourseId,
                            DateOnly? expireDate)
        {
            this.Code = code;
            this.Description = description;
            this.Precentage = precentage;
            this.SpecifiedUserId = specifiedUserId;
            this.SpecifiedCourseId = specifiedCourseId;
            this.ExpireDate = expireDate;
            this.Expired = false;
        }

        public string Code { get; private set; }
        public int Precentage { get; private set; }
        public string? Description { get; private set; }

        public string? SpecifiedUserId { get; private set; }
        public User? SpecifiedUser { get; private set; }

        public int? SpecifiedCourseId { get; private set; }
        public Course? SpecifiedCourse { get; private set; }

        public DateOnly? ExpireDate { get; private set; }
        public bool Expired { get; private set; }


        public Discount UpdateExpiration(bool expired)
        {
            this.Expired = expired;

            return this;
        }
    }
}
