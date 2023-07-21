namespace Keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _repo;

  public KeepsService(KeepsRepository repo)
  {
    _repo = repo;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    Keep keep = _repo.CreateKeep(keepData);
    return keep;
  }

  internal List<Keep> GetAllKeeps()
  {
    List<Keep> keeps = _repo.GetAllKeeps();
    return keeps;
  }

  internal Keep GetById(int keepId, string userId)
  {
    Keep keep = _repo.GetById(keepId);
    if (keep == null)
    {
      throw new Exception("No Keep here, fam");
    }

    keep.Views++;
    _repo.EditKeep(keep);
    return keep;
  }

  internal Keep EditKeep(Keep keepData)
  {
    Keep original = GetById(keepData.Id, keepData.CreatorId);

    if (original.CreatorId != keepData.CreatorId)
    {
      throw new Exception("You shall not pass");
    }

    original.CreatorId = keepData.CreatorId != null ? keepData.CreatorId : original.CreatorId;
    original.Name = keepData.Name != null ? keepData.Name : original.Name;
    original.Description = keepData.Description != null ? keepData.Description : original.Description;
    original.Img = keepData.Img != null ? keepData.Img : original.Img;
    original.Views = keepData.Views != 0 ? keepData.Views : original.Views;

    _repo.EditKeep(original);
    return original;
  }

  internal void DeleteKeep(int keepId, string userId)
  {
    Keep keep = GetById(keepId, userId);
    if (keep.CreatorId != userId) throw new Exception("Get outta here, nerd!");
    int rows = _repo.DeleteKeep(keepId);
    if (rows > 1) throw new Exception("I dunno");
  }

  // internal void DeleteVk(int vkId, string userId)
  // {
  //   VaultKeep vk = GetById(vkId);
  //   if (vk.CreatorId != userId) throw new Exception("Go away");
  //   int rows = _repo.DeleteVk(vkId);
  //   if (rows > 1) new Exception("oops");
  // }
}