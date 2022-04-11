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
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly RecipesService _recipesService;

    public AccountController(AccountService accountService, RecipesService recipesService)
    {
      _accountService = accountService;
      _recipesService = recipesService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("recipes")]
    [Authorize]
    public async Task<ActionResult<List<RecipeViewModel>>> GetMyRecipes()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<RecipeViewModel> recipes = _recipesService.GetRecipesByAccount(userInfo.Id);
        return Ok(recipes);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<Account>> Update([FromBody] Account updateData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Account update = _accountService.Edit(updateData, userInfo.Email);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}