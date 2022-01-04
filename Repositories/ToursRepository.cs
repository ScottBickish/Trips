using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Trips.Models;

namespace Trips.Repositories
{
  public class ToursRepository
  {
    private readonly IDbConnection _db;
    public ToursRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Tour Create(Tour newTour)
    {
      string sql = @"
      INSERT INTO tours
      (tourName, price, creatorId, destination)
      VALUES
      (@TourName, @Price, @CreatorId, @Destination);
      SELECT LAST_INSERT_ID();";

      int id = _db.ExecuteScalar<int>(sql, newTour);
      newTour.Id = id;
      return newTour;
    }

    internal List<Tour> GetByCreatorId(string id)
    {
      string sql = @"
      SELECT
      t.*,
      a.*
      FROM tours t
      JOIN accounts a ON t.creatorId = a.id
      WHERE t.creatorId = @id
      ;";
      return _db.Query<Tour, Profile, Tour>(sql, (Tour, prof) =>
      {
        Tour.Creator = prof;
        return Tour;

      }, new { id }).ToList();
    }
  }
}