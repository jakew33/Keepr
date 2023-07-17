namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProfilesController : ControllerBase
{
  private readonly ProfilesService _profilesService;
  private readonly Auth0Provider _auth;

  public ProfilesController(ProfilesService profilesService, Auth0Provider auth)
  {
    _profilesService = profilesService;
    _auth = auth;
  }

  [HttpGet]
  [Authorize]

  public async Task<ActionResult<Account>> GetById()
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_profilesService.GetById(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}