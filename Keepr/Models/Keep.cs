namespace Keepr;

public class Keep
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }

  public Account Creator { get; set; }
  // public Account Kept { get; set; }

}
public class KeepsInVault : Keep
{
  public int VaultKeepId { get; set; }
}