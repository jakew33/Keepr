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

  internal Keep GetById(int keepId)
  {
    Keep keep = _repo.GetById(keepId);
    if (keep == null) throw new Exception("No Keep here fam");
    return keep;
  }

  internal Keep EditKeep(Keep updateData)
  {
    Keep original = GetById(updateData.Id);

    original.CreatorId = updateData.CreatorId != null ? updateData.CreatorId : original.CreatorId;
    original.Name = updateData.Name != null ? updateData.Name : original.Name;
    original.Description = updateData.Description != null ? updateData.Description : original.Description;
    original.Img = updateData.Img != null ? updateData.Img : original.Img;

    _repo.EditKeep(original);
    return original;
  }
  internal void DeleteKeep(int keepId, string userId)
  {
    Keep keep = GetById(keepId);
    if (keep.CreatorId != userId) throw new Exception("Get outta here, nerd!");
    int rows = _repo.DeleteKeep(keepId);
    if (rows > 1) new Exception("I dunno");
  }
}