using System;

namespace Trips.Interfaces
{
    public interface IVacation
    {
         int Id {get; set;}
         DateTime CreatedAt {get; set;}
         DateTime UpdatedAt {get; set;}
         float Price {get; set;}
         string Destination {get; set;}
         string CreatorId {get; set;}

         


    }
}