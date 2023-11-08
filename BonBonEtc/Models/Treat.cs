using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BonBonEtc.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "This field cannot be left empty")]
    public string Name { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}