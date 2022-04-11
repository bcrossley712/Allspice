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
    private readonly StepsRepository _steRepo;

    public RecipesService(RecipesRepository recRepo, IngredientsRepository ingRepo, StepsRepository steRepo)
    {
      _recRepo = recRepo;
      _ingRepo = ingRepo;
      _steRepo = steRepo;
    }

    internal List<Recipe> GetAll()
    {
      List<Recipe> recipes = _recRepo.GetAll();
      foreach (Recipe r in recipes)
      {
        List<Ingredient> ingredients = _ingRepo.GetAll(r.Id);
        r.Ingredients = ingredients;
        List<Step> steps = _steRepo.GetAll(r.Id);
        r.Steps = steps;
      }
      return recipes;
    }

    internal Recipe GetById(int id)
    {
      Recipe found = _recRepo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Recipe Id");
      }
      List<Ingredient> ingredients = _ingRepo.GetAll(id);
      found.Ingredients = ingredients;
      List<Step> steps = _steRepo.GetAll(id);
      found.Steps = steps;
      return found;
    }
    internal List<RecipeViewModel> GetRecipesByAccount(string id)
    {
      return _recRepo.GetRecipesByAccount(id);
    }
    internal Recipe Create(Recipe recipeData)
    {
      Recipe created = _recRepo.Create(recipeData);
      List<Ingredient> ingredients = _ingRepo.GetAll(recipeData.Id);
      created.Ingredients = ingredients;
      List<Step> steps = _steRepo.GetAll(recipeData.Id);
      created.Steps = steps;
      return created;
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
      List<Ingredient> ingredients = _ingRepo.GetAll(original.Id);
      original.Ingredients = ingredients;
      List<Step> steps = _steRepo.GetAll(original.Id);
      original.Steps = steps;
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