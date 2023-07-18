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

  public async Task<ActionResult<Profile>> GetById()
  {
    try
    {
      Profile userInfo = await _auth.GetUserInfoAsync<Profile>(HttpContext);
      return Ok(_profilesService.GetById(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  // [HttpGet("{profileId}")]
  // public ActionResult<List<Keep>> GetProfileKeeps()
  // {
  //   try
  //   {
  //     List<Keep> keeps = _profilesService.GetProfileKeeps();
  //     return Ok(keeps);
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }
}