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

  internal Vault EditVault(Vault updateData)
  {
    Vault original = GetById(updateData.Id);

    original.CreatorId = updateData.CreatorId != null ? updateData.CreatorId : original.CreatorId;
    original.Name = updateData.Name != null ? updateData.Name : original.Name;
    original.Description = updateData.Description != null ? updateData.Description : original.Description;
    original.Img = updateData.Img != null ? updateData.Img : original.Img;

    _repo.EditVault(original);
    return original;
  }

  internal void DeleteVault(int vaultId, string userId)
  {
    Vault vault = GetById(vaultId);
    if (vault.CreatorId != userId) throw new Exception("Intruder Alert");
    int rows = _repo.DeleteVault(vaultId);
    if (rows > 1) new Exception("Not sure what happened there, chief");
  }
}