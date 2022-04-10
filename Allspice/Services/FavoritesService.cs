using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _favRepo;

    public FavoritesService(FavoritesRepository favRepo)
    {
      _favRepo = favRepo;
    }
    internal Favorite Create(Favorite favoriteData)
    {
      return _favRepo.Create(favoriteData);
    }
  }
}