namespace Keepr.Services;

public class ProfilesService
{
  private readonly ProfilesRepository _repo;
  private readonly VaultsService _vaultsService;

  public ProfilesService(ProfilesRepository repo, VaultsService vaultsService)
  {
    _repo = repo;
    _vaultsService = vaultsService;
  }

  internal Profile GetProfileById(Profile userInfo)
  {
    Profile profile = _repo.GetProfileById(userInfo.Id);
    return profile;
  }

  internal Keep GetOneKeep(int id)
  {
    Keep keep = _repo.GetOneKeep(id);
    if (keep == null)
    {
      throw new Exception("wrong.");
    }
    return keep;
  }

  internal List<Keep> GetUserKeeps(int vaultId, string userId)
  {
    _vaultsService.GetById(vaultId, userId);

    List<Keep> keeps = _repo.GetUserKeeps(vaultId);
    return keeps;
  }
}