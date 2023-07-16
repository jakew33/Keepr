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

  // internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  // {
  //   VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
  //   vaultKeep.CreatedAt = DataSetDateTime.Now;
  // }
}