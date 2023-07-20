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

  [HttpGet("{profileId}")]
  [Authorize]
  public ActionResult<Profile> GetProfileById(string profileId)
  {
    try
    {
      return Ok(_profilesService.GetProfileById(profileId));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{profileId}/keeps")]
  public async Task<ActionResult<List<Keep>>> GetUserKeeps(string profileId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      List<Keep> keeps = _profilesService.GetUserKeeps(profileId, userInfo?.Id);

      return Ok(keeps);
    }
    catch (Exception e)
    {
      return (BadRequest(e.Message));
    }
  }

  [HttpGet("{profileId}/vaults")]
  public async Task<ActionResult<List<Vault>>> GetUserVaults(string profileId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _profilesService.GetUserVaults(profileId, userInfo?.Id);

      return Ok(vaults);
    }
    catch (Exception e)
    {
      return (BadRequest(e.Message));
    }
  }
}