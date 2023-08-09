// Libs
using System.Diagnostics.CodeAnalysis;

namespace Models.Enemies;

// Class
class Slime : Enemy {
  [SetsRequiredMembers]
  public Slime() {
    Damage = new Random().Next(1, Game.character.lifeMax / 4);
    Exp = new Random().Next(Life / 2, Life);
    Life = new Random().Next(1, Game.character.lifeMax / 2);
    Name = "Slime";
  }
}