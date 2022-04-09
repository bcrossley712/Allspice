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
  public class StepsController : ControllerBase
  {
    private readonly StepsService _stepsService;

    public StepsController(StepsService stepsService)
    {
      _stepsService = stepsService;
    }
    [HttpGet]
    public ActionResult<List<Step>> GetAll()
    {
      try
      {
        List<Step> steps = _stepsService.GetAll();
        return Ok(steps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Step> GetById(int id)
    {
      try
      {
        Step step = _stepsService.GetById(id);
        return Ok(step);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Step>> CreateAsync([FromBody] Step stepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Step step = _stepsService.Create(userInfo.Id, stepData);
        return Created($"api/steps/{step.Id}", step);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Step>> Update(int id, [FromBody] Step updateData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Step update = _stepsService.Update(userInfo.Id, id, updateData);
        return Created($"api/steps/{update.Id}", update);
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
        _stepsService.Remove(userInfo.Id, id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}