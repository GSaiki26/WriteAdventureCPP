// Libs
using System.Diagnostics.CodeAnalysis;

namespace Models.Enemies;

// Class
class Golem : Enemy {
  [SetsRequiredMembers]
  public Golem() {
    Damage = new Random().Next(1, Game.character.strength * 2);
    Exp = new Random().Next(Life / 2, Life);
    Life = new Random().Next(1, Game.character.lifeMax * 2);
    Name = "Golem";
  }
}