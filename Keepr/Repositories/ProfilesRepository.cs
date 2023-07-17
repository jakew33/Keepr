namespace Keepr.Repositories;

public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetById(string ProfileId)
  {
    string sql = @"SELECT * FROM profiles WHERE id =@";
    return _db.QueryFirstOrDefault<Profile>(sql, new { ProfileId });
  }
}