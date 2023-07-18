namespace Keepr.Services;

public class ProfilesService
{
  private readonly ProfilesRepository _repo;

  public ProfilesService(ProfilesRepository repo)
  {
    _repo = repo;
  }

  internal Profile GetById(Profile userInfo)
  {
    Profile profile = _repo.GetById(userInfo.Id);
    return profile;
  }

  internal List<Keep> GetProfileKeeps()
  {
    List<Keep> keeps = _repo.GetProfileKeeps();
    return keeps;
  }
}