namespace Keepr.Repositories;

public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetById(string id)
  {
    string sql = @" SELECT * FROM accounts WHERE accounts.id = @id ;";
    return _db.QueryFirstOrDefault<Profile>(sql, new { id });
  }

  // internal List<Keep> GetUserKeeps()
  // {
  //   string sql = @"
  //   SELECT
  //   k.*
  //   creator.*
  //   FROM keeps k
  //   JOIN accounts creator ON k.creatorId = creator.id
  //   ;";

  //   List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
  //   {
  //     keep.Creator = creator;
  //     return keep;
  //   }).ToList();
  //   return keeps;
  // }
}