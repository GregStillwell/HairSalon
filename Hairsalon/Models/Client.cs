using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<Stylist> Stylist { get; set; }
  }
}