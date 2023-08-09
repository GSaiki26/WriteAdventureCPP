// Libs
using System.Diagnostics.CodeAnalysis;
namespace Models.Items;

// Class
public class WeaponSword : Weapon {
  [SetsRequiredMembers]
  public WeaponSword() {
    Damage = new Random().Next(10, 20);
    Durability = new Random().Next(14, 18);
    DurabilityMax = Durability;
    Name = "Espada";
    Stamina = new Random().Next(12, 26);
  }
}
