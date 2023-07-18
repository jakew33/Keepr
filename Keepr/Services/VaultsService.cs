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

  internal Vault GetById(int vaultId, string userId)
  {
    Vault vault = _repo.getById(vaultId);
    if (vault == null)
    {
      throw new Exception("bruh");
    }

    if (userId != vault.CreatorId && vault.IsPrivate)
    {
      throw new Exception("Get Outta Here!");
    }
    return vault;
  }

  internal Vault EditVault(Vault vaultData)
  {
    Vault original = GetById(vaultData.Id, vaultData.CreatorId);

    if (original.CreatorId != vaultData.CreatorId)
    {
      throw new Exception("I don't know what to put here");
    }

    original.CreatorId = vaultData.CreatorId != null ? vaultData.CreatorId : original.CreatorId;
    original.Name = vaultData.Name != null ? vaultData.Name : original.Name;
    original.Description = vaultData.Description != null ? vaultData.Description : original.Description;
    original.Img = vaultData.Img != null ? vaultData.Img : original.Img;

    _repo.EditVault(original);
    return original;
  }

  internal void DeleteVault(int vaultId, string userId)
  {
    Vault vault = GetById(vaultId, userId);
    if (vault.CreatorId != userId) throw new Exception("Intruder Alert");
    int rows = _repo.DeleteVault(vaultId);
    if (rows > 1) new Exception("Not sure what happened there, chief");
  }
}