namespace Keepr.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    string sql = @"
    INSERT INTO vaults
    (creatorId, name, description, img, isPrivate)
    VALUES
    (@CreatorId, @Name, @Description, @Img, @IsPrivate);

    SELECT
    v.*,
    creator.*
    FROM vaults v
    JOIN accounts creator ON v.creatorId = creator.id
    WHERE v.id = LAST_INSERT_ID()
    ;";

    Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, creator) =>
    {
      vault.Creator = creator;
      return vault;
    }, vaultData).FirstOrDefault();
    return vault;
  }

  internal Vault getById(int vaultId)
  {
    string sql = @"
    SELECT
    v.*,
    creator.*
    FROM vaults v
    JOIN accounts creator ON v.creatorID = creator.id
    WHERE v.id = @vaultId;
    ;";

    Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, creator) =>
    {
      vault.Creator = creator;
      return vault;
    }, new { vaultId }).FirstOrDefault();
    return vault;
  }

  internal void EditVault(Vault vault)
  {
    string sql = @"
    UPDATE vaults 
    SET
    creatorId = @creatorId,
    name = @name,
    description = @description,
    img = @img,
    isPrivate = @isPrivate
    WHERE id = @id;
    ;";
    _db.Execute(sql, vault);
  }

  internal int DeleteVault(int vaultId)
  {
    string sql = @"
    DELETE FROM vaults
    WHERE id = @vaultId LIMIT 1
    ;";

    int rows = _db.Execute(sql, new { vaultId });
    return rows;
  }
}