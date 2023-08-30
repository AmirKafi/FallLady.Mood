using FallLady.Mood.Application.Contract.Dto.Favourites;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Interfaces.Favourites
{
    public interface IFavouriteService
    {
        Task<ServiceResponse<bool>> AddToFavourites(FavouriteDto dto);
        Task<ServiceResponse<bool>> IsFavourite(string userId, FormEnum disclaimer, int disclaimerId);
    }
}
