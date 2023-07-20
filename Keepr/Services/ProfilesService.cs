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

  internal Profile GetProfileById(string profileId)
  {
    Profile profile = _repo.GetProfileById(profileId);
    return profile;
  }

  // internal Keep GetOneKeep(int id)
  // {
  //   Keep keep = _repo.GetOneKeep(id);
  //   if (keep == null)
  //   {
  //     throw new Exception("wrong.");
  //   }
  //   return keep;
  // }

  internal List<Keep> GetUserKeeps(string profileId, string userId)
  {
    List<Keep> keeps = _repo.GetUserKeeps(profileId);
    return keeps;
  }

  internal List<Vault> GetUserVaults(string profileId, string userId)
  {
    List<Vault> vaults = _repo.GetUserVaults(profileId);
    return vaults;
  }
}