// Libs
using System.Diagnostics.CodeAnalysis;
namespace Models.Items;

// Class
public class PotionLife : Potion {
  [SetsRequiredMembers]
  public PotionLife() {
    Effect = new Random().Next(1, 20);
    Name = $"Poção de Vida +{Effect}";
  }
}
