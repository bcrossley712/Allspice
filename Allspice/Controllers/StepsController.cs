using Allspice.Services;
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
  }
}