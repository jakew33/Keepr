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

  // internal List<VaultKeep> GetKeepsInVault(int vkId)
  // {
  //   List<VaultKeep> vks = _repo.GetKeepsInVault(vkId);
  //   return vks;
  // }

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