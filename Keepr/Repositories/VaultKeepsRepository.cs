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
    (vaultId, keepId, creatorId, id, vaultKeepId)
    VALUES
    (@VaultId, @KeepId, @CreatorId, @Id, @VaultKeepId);
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
  //   v.*,
  //   acct.*
  //   FROM keeps vk
  //   JOIN vaultKeeps vk ON k.id = vk.keepId
  //   JOIN vault v ON vk vaultId = v.Id
  //   JOIN accounts acct ON acct.id = v.creatorId
  //   WHERE vk.vaultId = @vaultId
  //   ;";

  //   List<VaultKeep> keeps = _db.Query<VaultKeep, Keep, VaultKeep, Account>(sql, (k, vk, acct) =>
  //   {
  //     k.CreatorId = .Id;
  //     vk.Id = vk.Id;
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
    WHERE vk.id = @VaultKeepId
    ;";

    VaultKeep vk = _db.Query<VaultKeep>(sql, new { vkId }).FirstOrDefault();
    return vk;
  }

  internal int DeleteVk(int vkId)
  {
    string sql = @"
    DELETE FROM vaultKeeps
    WHERE id = @keepId LIMIT 1
    ;";

    int rows = _db.Execute(sql, new { vkId });
    return rows;
  }
}