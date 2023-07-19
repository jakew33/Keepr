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
  public ActionResult<Profile> GetProfileById(string id)
  {
    try
    {
      return Ok(_profilesService.GetProfileById(id));
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
}