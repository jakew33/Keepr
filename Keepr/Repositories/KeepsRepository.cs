namespace Keepr.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    string sql = @"
    INSERT INTO keeps 
    (creatorId, name, description, img, views, kept)
    VALUES 
    (@creatorId, @name, @description, @img, @views, @kept);

    SELECT
    k.*,
    creator.*
    FROM keeps k
    JOIN accounts creator ON k.creatorId = creator.id
    WHERE k.id = LAST_INSERT_ID() 
    ;";

    Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;

    }, keepData).FirstOrDefault();
    return keep;
  }

  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
    SELECT
    k.*,
    creator.* 
    FROM keeps k
    JOIN accounts creator ON k.creatorId = creator.id
    ;";
    List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }).ToList();
    return keeps;
  }

  internal Keep GetById(int keepId)
  {
    string sql = @"
    SELECT
    k.*,
    creator.*
    FROM keeps k
    JOIN accounts creator ON k.creatorId = creator.id
    WHERE k.id = @keepId
    ;";

    Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }, new { keepId }).FirstOrDefault();
    return keep;
  }

  internal void EditKeep(Keep original)
  {
    string sql = @"
    UPDATE keeps 
    SET
    name = @name,
    creatorId = @creatorId,
    description = @description,
    img = @img
    WHERE id = @id
    ;";

    _db.Execute(sql, original);
  }

  internal int DeleteKeep(int keepId)
  {
    string sql = @"
    DELETE FROM keeps
    WHERE id = @keepId LIMIT 1
    ;";

    int rows = _db.Execute(sql, new { keepId });
    return rows;
  }
}