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
    (@creatorId, @name, @description, @img, @isPrivate);

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
}