namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth;

  public VaultsController(VaultsService vaultsService, KeepsService keepsService, VaultKeepsService vaultKeepsService, Auth0Provider auth)
  {
    _vaultsService = vaultsService;
    _keepsService = keepsService;
    _vaultKeepsService = vaultKeepsService;
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

  [HttpGet("{vaultId}")]
  public ActionResult<Vault> GetById(int vaultId)
  {
    try
    {
      Vault vault = _vaultsService.GetById(vaultId);
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{vaultId}")]
  [Authorize]
  public ActionResult<Vault> EditVault(int vaultId, [FromBody] Vault updateData)
  {
    try
    {
      updateData.Id = vaultId;
      Vault vault = _vaultsService.EditVault(updateData);
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{vaultId}")]
  [Authorize]

  public async Task<ActionResult<Vault>> DeleteVault(int vaultId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>
      (HttpContext);
      _vaultsService.DeleteVault(vaultId, userInfo.Id);
      return Ok("deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  // [HttpGet("{vaultId}/keeps")]
  // [Authorize]
  // public ActionResult<List<Keep>> GetKeepsInVault(int vaultId)
  // {
  //   try
  //   {
  //     List<Keep> keeps = _vaultKeepsService.GetKeepsInVault(vaultId);
  //     return keeps;
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }

}