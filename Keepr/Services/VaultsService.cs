namespace Keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _repo;

  public VaultsService(VaultsRepository repo)
  {
    _repo = repo;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    Vault vault = _repo.CreateVault(vaultData);
    return vault;
  }

  internal Vault GetById(int vaultId)
  {
    Vault vault = _repo.getById(vaultId);
    if (vault == null) throw new Exception($"{vaultId}: Whoops");
    return vault;
  }

}