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

  internal List<KeepsInVault> GetKeepsInVault(int vaultId)
  {
    string sql = @"
    SELECT
    vk.*,
    k.*,
    acct.*
    FROM vaultKeeps vk
    JOIN keeps k ON vk.keepId = k.id
    JOIN accounts acct ON acct.id = vk.creatorId
    WHERE vk.vaultId = @vaultId
    ;";

    List<KeepsInVault> keeps = _db.Query<VaultKeep, KeepsInVault, Account, KeepsInVault>(sql, (vk, kinv, acct) =>
    {
      kinv.VaultKeepId = vk.Id;
      kinv.Creator = acct;
      return kinv;
    }, new { vaultId }).ToList();

    return keeps;
  }

  //TODO FIX WHATEVER'S WRONG WITH THIS
  internal VaultKeep GetById(int vkId)
  {
    string sql = @"
    SELECT
    vk.*
    FROM vaultKeeps vk
    WHERE vk.id = @vkId
    ;";
    VaultKeep vk = _db.Query<VaultKeep>(sql, new { vkId }).FirstOrDefault();
    return vk;
  }

  internal int DeleteVk(int vkId)
  {
    string sql = @"
    DELETE 
    FROM vaultKeeps 
    WHERE id = @vkId 
    LIMIT 1
    ;";
    int rows = _db.Execute(sql, new { vkId });
    return rows;
  }
}