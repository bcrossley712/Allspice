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
  }
}