using FallLady.Mood.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Configs
{
    public class Config:EntityId<int>
    {
        #region Constructor
        public Config(string? email, string? address, string? contactNumber)
        {
            Email = email;
            Address = address;
            ContactNumber = contactNumber;
        }

        #endregion

        #region Properties
        public string? Email { get; set; }
        public string? Address { get; set; }

        public string? ContactNumber { get; set; }

        #endregion

        #region Methods

        public Config Update(string? email, string? address, string? contactNumber)
        {
            Email = email;
            Address = address;
            ContactNumber = contactNumber;

            return this;
        }
        #endregion


    }
}
