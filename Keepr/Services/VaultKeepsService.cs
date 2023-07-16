namespace Keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;
  private readonly KeepsService _keepsService;

  public VaultKeepsService(VaultKeepsRepository repo, KeepsService keepsService)
  {

    _repo = repo;
    _keepsService = keepsService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vkData)
  {
    VaultKeep newVk = _repo.CreateVaultKeep(vkData);
    return newVk;
  }
}