using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trips.Models;
using Trips.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Trips.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly ToursService _ts;

    public AccountController(AccountService accountService, ToursService ts)
    {
      _accountService = accountService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("tours")]
    [Authorize]
    public async Task<ActionResult<List<Tour>>> GetTours()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Tour> tour = _ts.GetByAccountId(userInfo.Id);
        return Ok(tour);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }


}