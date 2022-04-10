using System;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class StepsService
  {
    private readonly StepsRepository _steRepo;
    private readonly RecipesService _recipesService;

    public StepsService(StepsRepository steRepo, RecipesService recipesService)
    {
      _steRepo = steRepo;
      _recipesService = recipesService;
    }

    internal Step GetById(int id)
    {
      Step found = _steRepo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Step Id");
      }
      return found;
    }

    internal Step Create(string userId, Step stepData)
    {
      Recipe foundRecipe = _recipesService.GetById(stepData.RecipeId);
      if (userId != foundRecipe.CreatorId)
      {
        throw new Exception("You did not create this recipe so you cannot add steps to it");
      }
      return _steRepo.Create(stepData);
    }

    internal Step Update(string userId, Step updateData)
    {
      Step original = GetById(updateData.Id);
      Recipe foundRecipe = _recipesService.GetById(original.RecipeId);
      if (userId != foundRecipe.CreatorId)
      {
        throw new Exception("You did not create this recipe so you cannot edit steps on it");
      }
      original.Body = updateData.Body ?? original.Body;
      original.Sequence = updateData.Sequence != 0 ? updateData.Sequence : original.Sequence;
      _steRepo.Update(updateData);
      return original;
    }
    internal void Remove(string userId, int id)
    {
      Step stepToDelete = GetById(id);
      Recipe foundRecipe = _recipesService.GetById(stepToDelete.RecipeId);
      if (userId != foundRecipe.CreatorId)
      {
        throw new Exception("You did not create this recipe so you cannot remove steps from it");
      }
      _steRepo.Remove(id);
    }
  }
}