using FallLady.Mood.Domain.Domain.Favourites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Favourites
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly FallLadyDbContext _db;
        public FavouriteRepository(FallLadyDbContext db)
        {
            _db = db;
        }

        public async Task AddToFavourite(Favourite favourite)
        {
            await _db.AddAsync(favourite);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Favourite>> GetFavourites(string userId)
        {
            return await _db.Favourites.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
