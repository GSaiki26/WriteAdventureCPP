// Libs
using System.Diagnostics.CodeAnalysis;
namespace Models.Items;

// Class
public class PotionStamina : Potion {
  [SetsRequiredMembers]
  public PotionStamina() {
    Effect = new Random().Next(1, 20);
    Name = $"Poção de Estamina +{Effect}";
  }
}
