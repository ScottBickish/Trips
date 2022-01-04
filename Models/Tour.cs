using System;
using Trips.Interfaces;

namespace Trips.Models
{
  public class Tour : IVacation
  {
    public string TourName { get; set; }
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public float Price { get; set; }
    public string Destination { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}