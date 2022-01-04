using System;
using System.Collections.Generic;
using Trips.Models;
using Trips.Repositories;

namespace Trips.Services
{
  public class ToursService
  {
    private readonly ToursRepository _repo;

    public ToursService(ToursRepository repo)
    {
      _repo = repo;
    }

    internal Tour Create(Tour newTour)
    {
      return _repo.Create(newTour);
    }

    internal List<Tour> GetByAccountId(string id)
    {
      return _repo.GetByCreatorId(id);
    }
  }
}