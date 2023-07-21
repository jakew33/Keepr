namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth0;

  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth0)
  {
    _vaultKeepsService = vaultKeepsService;
    _auth0 = auth0;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vkData)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      vkData.CreatorId = userInfo.Id;
      // TODO make sure to pass userId here so we can do our logic in the service
      VaultKeep newVk = _vaultKeepsService.CreateVaultKeep(vkData, userInfo.Id);
      vkData.CreatorId = userInfo?.Id;
      return Ok(newVk);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  // [HttpGet("{VaultKeepId}")]
  // public ActionResult<VaultKeep> GetById(int vkId)
  // {
  //   try
  //   {
  //     VaultKeep vk = _vaultKeepsService.GetById(vkId);
  //     return Ok(vk);
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }

  [HttpDelete("{vaultKeepId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteVk(int vaultKeepId)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _vaultKeepsService.DeleteVk(vaultKeepId, userInfo.Id);
      return Ok("deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}