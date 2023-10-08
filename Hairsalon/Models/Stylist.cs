namespace Hairsalon.Models

{
public class Stylists
  {
  public int StylistsId { get; set;  }
  public string Name {get; set; }
  public string Description { get; set; }
  public int ClientId { get; set; }
  public Client Client { get; set; }

  }
}