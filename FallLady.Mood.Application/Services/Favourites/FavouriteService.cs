using FallLady.Mood.Application.Contract.Dto.Favourites;
using FallLady.Mood.Application.Contract.Interfaces.Favourites;
using FallLady.Mood.Application.Contract.Mappers.Favourites;
using FallLady.Mood.Domain.Domain.Favourites;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Favourites
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _repository;
        private readonly IMemoryCache _cache;

        public FavouriteService(IFavouriteRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }


        public async Task<ServiceResponse<bool>> AddToFavourites(FavouriteDto dto)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                await _repository.AddToFavourite(dto.ToModel());

                var favs = await _repository.GetFavourites(dto.UserId);

                _cache.Remove("UserFavourites");
                _cache.Set("UserFavourites",favs);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }
            return result;
        }
    }
}
