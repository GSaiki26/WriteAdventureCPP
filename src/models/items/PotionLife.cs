// Class
namespace Items {
class PotionLife : Potion {
  public PotionLife() {
    Name = "Poção de Vida";
    Effect = new Random().Next(1, 20);
  }
}
}