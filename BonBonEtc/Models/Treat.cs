using System.Collections.Generic;

namespace BonBonEtc.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    public string Name { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}