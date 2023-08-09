// Libs
using System.Diagnostics.CodeAnalysis;

namespace Models.Enemies;

// Class
class Dragon : Enemy {
  [SetsRequiredMembers]
  public Dragon() {
    Damage = new Random().Next(Game.character.lifeMax / 4, Game.character.lifeMax);
    Exp = new Random().Next(Life / 2, Life);
    Life = Game.character.lifeMax * 4;
    Name = "Dragon";
  }
}