// Libs
using System;

// Class
namespace Items {
abstract class WeaponAxe : Weapon {
  public WeaponAxe() {
    Name = "Machado";
    Damage = new Random().Next(20, 30);
    Durability = new Random().Next(4, 10);
    Stamina = new Random().Next(20, 30);
  }
}
}
