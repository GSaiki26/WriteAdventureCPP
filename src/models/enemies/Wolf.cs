// Libs
using System.Diagnostics.CodeAnalysis;

namespace Models.Enemies;

// Class
class Wolf : Enemy {
  [SetsRequiredMembers]
  public Wolf() {
    Damage = new Random().Next(1, Game.character.lifeMax / 2);
    Exp = new Random().Next(Life / 2, Life);
    Life = new Random().Next(1, Game.character.lifeMax / 3);
    Name = "Lobo";
  }
}