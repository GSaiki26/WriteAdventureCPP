// Libs
using System;

// Class
class Enemy {
  public string name;
  public int damage;
  public int life;

  public Enemy(string enemyName, int life, int damage) {
    this.name = enemyName;
    this.damage = damage;
    this.life = life;
  }
}