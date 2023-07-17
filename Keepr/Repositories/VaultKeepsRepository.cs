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
    (vaultId, keepId, creatorId)
    VALUES
    (@VaultId, @KeepId, @CreatorId);
    SELECT 
    LAST_INSERT_ID()
    ;";

    int id = _db.ExecuteScalar<int>(sql, vkData);
    vkData.Id = id;
    return vkData;
  }

  // internal List<VaultKeep> GetKeepsInVault(int vkId)
  // {
  //   string sql = @"
  //   SELECT
  //   vk.*,
  //   acct.* 
  //   FROM vaultKeeps vk
  //   JOIN accounts acct On acct.id = vk.creatorId
  //   WHERE vk.vaultId = @vaultId
  //   ;";

  //   List<VaultKeep> vks = _db.Query<VaultKeep, CacheProfile, VaultKeep>(sql, (vks, acct) =>
  //   {
  //     vks.CreatorId = acct;
  //   })
  // }
}