// Libs
using System.Diagnostics.CodeAnalysis;
namespace Models.Items;

// Class
public class WeaponAxe : Weapon {
  [SetsRequiredMembers]
  public WeaponAxe() {
    Damage = new Random().Next(20, 30);
    Durability = new Random().Next(4, 10);
    DurabilityMax = Durability;
    Name = "Machado";
    Stamina = new Random().Next(20, 30);
  }
}
