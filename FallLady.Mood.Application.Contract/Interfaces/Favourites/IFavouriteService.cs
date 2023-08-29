using FallLady.Mood.Application.Contract.Dto.Favourites;
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
    }
}
