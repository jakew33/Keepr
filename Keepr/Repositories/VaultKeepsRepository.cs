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

  // internal List<VaultKeep> GetKeepsInVault(int vaultKeepData)
  // {
  //   string sql =@"
  //   SELECT
  //   k.*,
  //   act.*
  //   FROM vaults v
  //   JOIN accounts act ON act.id = v.creatorId
  //   WHERE v.vaultId = @vaultKeepId
  //   ;";
  //   List<Keep> vaultKeeps = _db.Query<Keep, Account, Keep>(sql,(keep, account) =>
  //   {
  //     keep.Creator = account;
  //     return keep;
  //   }, new {vaultKeepData}).ToList();
  //   return vault;
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