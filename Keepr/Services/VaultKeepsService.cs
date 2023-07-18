namespace Keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository repo, KeepsService keepsService, VaultsService vaultsService)
  {

    _repo = repo;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vkData)
  {
    VaultKeep newVk = _repo.CreateVaultKeep(vkData);
    return newVk;
  }

  internal List<KeepsInVault> GetKeepsInVault(int vaultId)
  {
    List<KeepsInVault> keeps = _repo.GetKeepsInVault(vaultId);
    return keeps;
  }

  internal VaultKeep GetById(int vkId)
  {
    VaultKeep vk = _repo.GetById(vkId);
    if (vk == null) new Exception("Invalid Id");
    return vk;
  }

  internal void DeleteVk(int vkId, string userId)
  {
    VaultKeep vk = GetById(vkId);
    if (vk.CreatorId != userId) throw new Exception("Go away");
    int rows = _repo.DeleteVk(vkId);
    if (rows > 1) new Exception("oops");
  }
}