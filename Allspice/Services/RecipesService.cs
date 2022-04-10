using System;
using System.Collections.Generic;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _recRepo;
    private readonly IngredientsRepository _ingRepo;

    public RecipesService(RecipesRepository recRepo, IngredientsRepository ingRepo)
    {
      _recRepo = recRepo;
      _ingRepo = ingRepo;
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
        throw new Exception("Invalid Recipe Id");
      }
      return found;
    }

    internal Recipe Create(Recipe recipeData)
    {
      return _recRepo.Create(recipeData);
    }

    internal Recipe Update(Account userInfo, Recipe updateData)
    {
      Recipe original = GetById(updateData.Id);
      if (original.CreatorId != userInfo.Id)
      {
        throw new Exception("You cannot modify this");
      }
      original.Title = updateData.Title ?? original.Title;
      original.Subtitle = updateData.Subtitle ?? original.Subtitle;
      original.Category = updateData.Category ?? original.Category;
      original.ImgUrl = updateData.ImgUrl ?? original.ImgUrl;
      _recRepo.Update(original);
      return original;
    }
    internal void Remove(int id, Account userInfo)
    {
      Recipe recipe = GetById(id);
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("You cannot delete this");
      }
      _recRepo.Remove(id);
    }
  }
}