using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Favourites
{
    public interface IFavouriteRepository
    {
        Task AddToFavourite(Favourite favourite);
        Task<List<Favourite>> GetFavourites(string userId);
    }
}
