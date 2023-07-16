namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth;

  public KeepsController(KeepsService keepsService, Auth0Provider auth)
  {
    _keepsService = keepsService;
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
  public ActionResult<Keep> GetById(int keepId)
  {
    try
    {
      Keep keep = _keepsService.GetById(keepId);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{keepId}")]
  [Authorize]
  public ActionResult<Keep> EditKeep(int keepId, [FromBody] Keep updateData)
  {
    try
    {
      updateData.Id = keepId;
      Keep keep = _keepsService.EditKeep(updateData);
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
}