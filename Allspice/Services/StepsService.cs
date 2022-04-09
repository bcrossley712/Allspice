using System;
using System.Collections.Generic;
using Allspice.Models;
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

    internal List<Step> GetAll()
    {
      throw new NotImplementedException();
    }

    internal Step GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal Step Create(string userId, Step stepData)
    {
      throw new NotImplementedException();
    }

    internal Step Update(string userId, int id, Step updateData)
    {
      throw new NotImplementedException();
    }
    internal void Remove(string userId, int id)
    {
      throw new NotImplementedException();
    }
  }
}