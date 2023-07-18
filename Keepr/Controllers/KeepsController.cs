namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly ProfilesService _profilesService;
  private readonly Auth0Provider _auth;

  public KeepsController(KeepsService keepsService, VaultKeepsService vaultKeepsService, ProfilesService profilesService, Auth0Provider auth)
  {
    _keepsService = keepsService;
    _vaultKeepsService = vaultKeepsService;
    _profilesService = profilesService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;

      Keep keep = _keepsService.CreateKeep(keepData);
      return new ActionResult<Keep>(Ok(keep));
    }
    catch (Exception e)
    {
      return new ActionResult<Keep>(BadRequest(e.Message));
    }
  }

  [HttpGet]
  public ActionResult<List<Keep>> GetAllKeeps()
  {
    try
    {
      List<Keep> keeps = _keepsService.GetAllKeeps();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{keepId}")]
  public async Task<ActionResult<Keep>> GetById(int keepId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

      Keep keep = _keepsService.GetById(keepId, userInfo?.Id);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{keepId}")]
  [Authorize]
  public async Task<ActionResult<Keep>> EditKeep(int keepId, [FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.Id = keepId;
      keepData.CreatorId = userInfo.Id;
      Keep keep = _keepsService.EditKeep(keepData);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpDelete("{keepId}")]
  [Authorize]
  public async Task<ActionResult<Keep>> DeleteKeep(int keepId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      _keepsService.DeleteKeep(keepId, userInfo.Id);
      return Ok("delorted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  // [HttpGet("{keepId}/vaultKeeps")]
  // public ActionResult<List<VaultKeep>> GetVaultKeeps(int keepId)
  // {
  //   try
  //   {
  //     List<VaultKeep> vks = _vaultKeepsService.GetVaultKeeps(keepId);
  //     return Ok(vks);
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }

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