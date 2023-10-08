using System.Collections.Generic;

namespace Hairsalon.Models
{
  public class Client
  {
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<Stylists> Stylist { get; set; }
  }
}