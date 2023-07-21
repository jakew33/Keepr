namespace Keepr.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetByEmail(string userEmail)
  {
    string sql = "SELECT * FROM accounts WHERE email = @userEmail";
    return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
  }

  internal Account GetById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Account>(sql, new { id });
  }

  internal Account Create(Account newAccount)
  {
    string sql = @"
            INSERT INTO accounts
              (name, picture, email, id, coverImg)
            VALUES
              (@Name, @Picture, @Email, @Id, @CoverImg)";
    _db.Execute(sql, newAccount);
    return newAccount;
  }

  internal Account Edit(Account update)
  {
    string sql = @"
            UPDATE accounts
            SET 
              name = @Name,
              picture = @Picture,
              coverImg = @CoverImg
            WHERE id = @Id;";
    _db.Execute(sql, update);
    return update;
  }

  internal List<Vault> GetMyVaults(string creatorId)
  {
    string sql = @"
    SELECT
    v.*,
    act.*
    FROM vaults v
    JOIN accounts act ON v.creatorId = act.id
    WHERE v.creatorId = @creatorId
    ;";
    return _db.Query<Vault, Account, Vault>(sql, (vault, act) =>
    {
      vault.Creator = act;
      return vault;
    }, new { creatorId }).ToList();
  }
}

