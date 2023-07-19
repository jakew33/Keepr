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
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext); vkData.CreatorId = userInfo.Id;
      VaultKeep newVk = _vaultKeepsService.CreateVaultKeep(vkData);
      return Ok(newVk);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{VaultKeepId}")]
  public ActionResult<KeepsInVault> GetById(int kinvId)
  {
    try
    {
      KeepsInVault kinv = _vaultKeepsService.GetById(kinvId);
      return Ok(kinv);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{vaultKeepId}")]
  [Authorize]
  public async Task<ActionResult<KeepsInVault>> DeleteVk(int vkId)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _vaultKeepsService.DeleteVk(vkId, userInfo.Id);
      return Ok("deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}