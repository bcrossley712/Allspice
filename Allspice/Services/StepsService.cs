using Allspice.Repositories;

namespace Allspice.Services
{
  public class StepsService
  {
    private readonly StepsRepository _steRepo;

    public StepsService(StepsRepository steRepo)
    {
      _steRepo = steRepo;
    }
  }
}