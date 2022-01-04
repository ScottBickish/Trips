using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trips.Models;
using Trips.Services;

namespace Trips.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ToursController : ControllerBase
  {
    private readonly ToursService _ts;
    public ToursController(ToursService ts)
    {
      _ts = ts;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Tour>> Create([FromBody] Tour newTour)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newTour.CreatorId = userInfo.Id;
        Tour tour = _ts.Create(newTour);
        return Ok(tour);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}