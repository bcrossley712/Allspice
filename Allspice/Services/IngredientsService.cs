using System;
using System.Collections.Generic;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _ingRepo;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository ingRepo, RecipesService recipesService)
    {
      _ingRepo = ingRepo;
      _recipesService = recipesService;
    }

    internal List<Ingredient> GetAll()
    {
      return _ingRepo.GetAll();
    }

    internal Ingredient GetById(int id)
    {
      Ingredient found = _ingRepo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Ingredient Create(Account userInfo, Ingredient ingredientData)
    {
      Recipe foundRecipe = _recipesService.GetById(ingredientData.RecipeId);
      if (userInfo.Id != foundRecipe.CreatorId)
      {
        throw new Exception("You did not create this recipe so you cannot add ingredients to it");
      }
      return _ingRepo.Create(ingredientData);
    }
    internal Ingredient Update(string userId, int id, Ingredient update)
    {
      Recipe foundRecipe = _recipesService.GetById(update.RecipeId);
      if (userId != foundRecipe.CreatorId)
      {
        throw new Exception("You did not create this recipe so you cannot edit ingredients in it");
      }
      Ingredient original = GetById(id);
      original.Name = update.Name ?? original.Name;
      original.Quantity = update.Quantity ?? original.Quantity;
      _ingRepo.Update(original);
      return original;
    }
    internal void Remove(String userId, int id)
    {
      Ingredient toDelete = GetById(id);
      Recipe foundRecipe = _recipesService.GetById(toDelete.RecipeId);
      if (userId != foundRecipe.CreatorId)
      {
        throw new Exception("You did not create this recipe so you cannot remove ingredients from it");
      }
      _ingRepo.Remove(id);
    }

  }
}