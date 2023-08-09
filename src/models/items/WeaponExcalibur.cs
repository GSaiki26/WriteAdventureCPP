// Libs
using System.Diagnostics.CodeAnalysis;
namespace Models.Items;

// Class
public class WeaponExcalibur : Weapon {
  [SetsRequiredMembers]
  public WeaponExcalibur() {
    Damage = new Random().Next(Game.character.strength , Game.character.strength * 2);
    Durability = new Random().Next(1, Game.character.strength);
    DurabilityMax = Durability;
    Name = "Excalibur";
    Stamina = new Random().Next(12, 26);
  }
}
