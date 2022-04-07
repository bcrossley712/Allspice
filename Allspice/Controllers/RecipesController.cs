using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Allspice.Models;
using Allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService)
    {
      _recipesService = recipesService;
    }
    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
      try
      {
        List<Recipe> recipes = _recipesService.GetAll();
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Recipe> GetById(int id)
    {
      try
      {
        Recipe recipe = _recipesService.GetById(id);
        return Ok(recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.CreatorId = userInfo.Id;
        Recipe recipe = _recipesService.Create(recipeData);
        recipe.Creator = userInfo;
        return Created($"api/recipes/{recipe.Id}", recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> Update([FromBody] Recipe updateData, int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updateData.CreatorId = userInfo.Id;
        Recipe update = _recipesService.Update(id, updateData);
        return Created($"api/recipes/{update.Id}", update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _recipesService.Remove(id, userInfo);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}