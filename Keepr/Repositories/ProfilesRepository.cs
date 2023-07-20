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
  internal List<Keep> GetUserKeeps(string profileId)
  {
    string sql = @"
    SELECT
    k.*,
    acct.*
    FROM keeps k
    JOIN accounts acct ON acct.id = k.creatorId
    WHERE k.creatorId = @profileId
    ;";

    List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }, new { profileId }).ToList();
    return keeps;
  }

  internal List<Vault> GetUserVaults(string profileId)
  {
    string sql = @"
    SELECT
    v.*,
    acct.*
    FROM vaults v
    JOIN accounts acct ON acct.id = v.creatorId
    WHERE v.creatorId = @profileId
    ;";

    List<Vault> vaults = _db.Query<Vault, Account, Vault>(sql, (vault, creator) =>
    {
      vault.Creator = creator;
      return vault;
    }, new { profileId }).ToList();
    return vaults;
  }
}