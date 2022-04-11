using System;
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

    internal void Remove(string userId, int id)
    {
      Favorite favorite = _favRepo.GetById(id);
      if(favorite.AccountId != userId){
        throw new Exception("You cannot delete this");
      }
      _favRepo.Remove(id);
    }
  }
}