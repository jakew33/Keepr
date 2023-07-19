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

  internal Profile GetProfileById(string id)
  {
    Profile profile = _repo.GetProfileById(id);
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

  internal List<Keep> GetUserKeeps(string profileId, string userId)
  {
    List<Keep> keeps = _repo.GetUserKeeps(profileId);
    return keeps;
  }
}