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

  internal VaultKeep CreateVaultKeep(VaultKeep vkData, string userId)
  {
    Vault vault = _vaultsService.GetById(vkData.VaultId, userId);
    if (userId != vkData.CreatorId)
    {
      throw new Exception("Get outta here, nerd");
    }

    VaultKeep newVk = _repo.CreateVaultKeep(vkData);
    return newVk;
  }

  internal List<KeepsInVault> GetKeepsInVault(int vaultId, string userId)
  {
    Vault vault = _vaultsService.GetById(vaultId, userId);
    List<KeepsInVault> keeps = _repo.GetKeepsInVault(vaultId);



    return keeps;
  }

  internal VaultKeep GetById(int vkId)
  {
    VaultKeep vk = _repo.GetById(vkId);
    if (vk == null) new Exception("Wrong Id, chief");
    return vk;
  }

  internal string DeleteVk(int vkId, string userId)
  {
    VaultKeep vk = GetById(vkId);
    if (vk.CreatorId != userId) throw new Exception("Go away");
    int rows = _repo.DeleteVk(vkId);
    if (rows > 1) new Exception("oops");
    return ("Removed VaultKeep");
  }
}