using Allspice.Repositories;

namespace Allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _ingRepo;

    public IngredientsService(IngredientsRepository ingRepo)
    {
      _ingRepo = ingRepo;
    }
  }
}