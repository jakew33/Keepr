namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth;

  public VaultsController(VaultsService vaultsService, Auth0Provider auth)
  {
    _vaultsService = vaultsService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>
      (HttpContext);
      vaultData.CreatorId = userInfo.Id;

      Vault vault = _vaultsService.CreateVault(vaultData);
      return new ActionResult<Vault>(Ok(vault));
    }
    catch (Exception e)
    {
      return new ActionResult<Vault>(BadRequest(e.Message));
    }
  }
}