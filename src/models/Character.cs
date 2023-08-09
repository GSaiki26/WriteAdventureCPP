// Libs
using Models.Items;

namespace Models;

// Class
public class Character {
  private int exp = 0;
  private int expMax = 100;
  public int life = 100;
  public int lifeMax = 100;
  public int level = 1;
  public int strength = 1;
  public int stamina = 100;
  public int staminaMax = 100;
  public Inventory<Weapon> weaponInventory = new(6);
  public Inventory<Potion> potionInventory = new(6);

  /// <summary>
  /// A method to add some experience to the character.
  /// </summary>
  /// <returns>
  /// Returns the number of level that was increased.
  /// </returns>
  public void AddExp(int expAmount) {
    string text = $"Você recebeu +{expAmount} de experiência.";
    // Add the exp amount to the character's exp.
    exp += expAmount;

    // Count the number of levels that the character has increased.
    int levelsCount = 0;
    while ( expMax <= exp ) {
      IncreaseStats();
      levelsCount++;
    }

    // Write the message on the game screen.
    if (levelsCount != 0) text += $"\nVocê subiu +{levelsCount} níveis. Seus status aumentaram.";
    Game.WriteMessage(text);
  }

  /// <summary>
  /// A method to add some life to the character.
  /// </summary>
  public void AddLife(int lifeAmount) {
    // Add the life amount to the character's life.
    life += lifeAmount;

    // Define the life eq to lifeMax if it's higher than the max.
    if (life >= lifeMax) life = lifeMax;
  }

  /// <summary>
  /// A method to add some stamina to the character.
  /// </summary>
  public void AddStam(int staminaAmount) {
    // Add the stamina amount to the character's stamina.
    stamina += staminaAmount;

    // Define the stamina eq to staminaMax if it's higher than the max.
    if (stamina >= staminaMax) stamina = staminaMax;
  }

  /// <summary>
  /// A method to show the current status from the character.
  /// </summary>
  public void ShowStatus() {
    string text = (
      "Seu status:"
      +$"Nível: {level} ({exp}/{expMax})"
      +$"Vida: {life}/{lifeMax}"
      +$"Estamina: {stamina}/{staminaMax}"
      +$"Força: {strength}");
    Game.WriteMessage(text, ConsoleColor.DarkYellow);
  }

  /// <summary>
  /// A method to increase the character's level.
  /// </summary>
  private void IncreaseStats() {
    // Add 1 level to the character's level and manipule the properties.
    level++;
    exp -= expMax;
    expMax += 5;
    strength += 2;
    life = 5;
    lifeMax = 5;
    stamina += 5;
    staminaMax += 5;
  }
}
