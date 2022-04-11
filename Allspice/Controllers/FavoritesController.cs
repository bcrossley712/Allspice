using System;
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
  public class FavoritesController : ControllerBase
  {
    private readonly FavoritesService _favoritesService;

    public FavoritesController(FavoritesService favoritesService)
    {
      _favoritesService = favoritesService;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> Create([FromBody] Favorite favoriteData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        favoriteData.AccountId = userInfo.Id;
        Favorite favorite = _favoritesService.Create(favoriteData);
        return Created($"api/favorites/{favorite.Id}", favorite);

      }
      catch (System.Exception e)
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
        _favoritesService.Remove(userInfo.Id, id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}