using System.Collections.Generic;

namespace BonBonEtc.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public string Name { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}