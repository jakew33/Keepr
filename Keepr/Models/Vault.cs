namespace Keepr;

public class Vault
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Image { get; set; }
  public bool IsPrivate { get; set; }
  public Account Creator { get; set; }
}