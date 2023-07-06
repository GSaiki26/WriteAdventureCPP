// Libs
using System;

// Class
namespace Items {
abstract class WeaponSword : Weapon {
  public WeaponSword() {
    Name = "Espada";
    Damage = new Random().Next(10, 20);
    Durability = new Random().Next(14, 18);
    Stamina = new Random().Next(12, 26);
  }
}
}
