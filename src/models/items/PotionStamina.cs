// Class
namespace Items {
class PotionStamina : Potion {
  public PotionStamina() {
    Name = "Poção de Estamina";
    Effect = new Random().Next(1, 20);
  }
}
}