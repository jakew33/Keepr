namespace Keepr.Repositories;
public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vkData)
  {
    string sql = @"
    INSERT INTO vaultKeeps
    (vaultId, keepId, creatorId, id)
    VALUES
    (@VaultId, @KeepId, @CreatorId, @Id);
    SELECT 
    LAST_INSERT_ID()
    ;";

    int id = _db.ExecuteScalar<int>(sql, vkData);
    vkData.Id = id;
    return vkData;
  }

  // internal List<VaultKeep> GetKeepsInVault(int vaultId)
  // {
  //   string sql = @"
  //   SELECT
  //   k.*,
  //   acct.*
  //   FROM keeps k
  //   JOIN accounts acct ON acct.id = k.creatorId
  //   WHERE k.vaultId = @vaultId
  //   ;";

  //   List<Keep> keeps = _db.Query<Keep, Vault, Keep>(sql, (k, acct) =>
  //   {
  //     k.Creator = vault;
  //     return k;
  //   }, new { vaultId }).ToList();

  //   return keeps;
  // }

  //TODO FIX WHATEVER'S WRONG WITH THIS
  internal VaultKeep GetById(int vkId)
  {
    string sql = @"
    SELECT
    vk.*,
    creator.*
    FROM vaultKeeps vk
    JOIN accounts creator ON vk.creatorId = creator.id
    WHERE vk.id = @vaultKeepId
    ;";

    VaultKeep vk = _db.Query<VaultKeep>(sql, new { vkId }).FirstOrDefault();
    return vk;
  }

  internal int DeleteVk(int vkId)
  {
    string sql = @"
    DELETE FROM vaultKeeps
    WHERE id = @vaultKeepId LIMIT 1
    ;";

    int rows = _db.Execute(sql, new { vkId });
    return rows;
  }
}