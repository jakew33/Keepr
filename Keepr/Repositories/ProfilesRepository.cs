namespace Keepr.Repositories;

public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetProfileById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Profile>(sql, new { id });
  }

  internal Keep GetOneKeep(int id)
  {
    string sql = "SELECT * FROM keeps WHERE id = @id;";

    Keep keep = _db.Query<Keep>(sql, new { id }).FirstOrDefault();
    return keep;
  }
  internal List<Keep> GetUserKeeps(int vaultId)
  {
    string sql = @"
    SELECT
    k.*
    acct.*
    FROM keeps k
    JOIN accounts acct ON acct.id = k.creatorId
    WHERE k.vaultId = @vaultId
    ;";

    List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }).ToList();
    return keeps;
  }
}