using System;
using System.Collections.Generic;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _recRepo;

    public RecipesService(RecipesRepository recRepo)
    {
      _recRepo = recRepo;
    }

    internal List<Recipe> GetAll()
    {
      return _recRepo.GetAll();
    }

    internal Recipe GetById(int id)
    {
      Recipe found = _recRepo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Recipe Create(Recipe recipeData)
    {
      return _recRepo.Create(recipeData);
    }

    internal Recipe Update(int id, Recipe updateData)
    {
      throw new NotImplementedException();
    }
    internal void Remove(int id, Account userInfo)
    {
      throw new NotImplementedException();

    }
  }
}