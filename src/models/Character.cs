// Class
class Character {
  public int exp = 0;
  private int expMax = 100;
  public int life = 100;
  private int lifeMax = 100;
  private int level = 1;
  public int strength = 1;
  public int stamina = 100;
  public int staminaMax = 100;
  public Inventory<Items.Weapon> weaponInventory = new(6);
  public Inventory<Items.Potion> potionInventory = new(6);

  /// <summary>
  /// A method to add some experience to the character.
  /// </summary>
  /// <returns>
  /// Returns the number of level that was increased.
  /// </returns>
  public int AddExp(int expAmount) {
    // Add the exp amount to the character's exp.
    exp += expAmount;

    // Count the number of levels that the character has increased.
    int levelsCount = 0;
    while ( expMax <= exp ) {
      LevelUp();
      levelsCount++;
    }

    return levelsCount;
  }

  public void ShowStatus() {
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Seu status:");
    Console.WriteLine($"Nível: {level} ({exp}/{expMax})");
    Console.WriteLine($"Vida: {life}/{lifeMax}");
    Console.WriteLine($"Estamina: {stamina}/{staminaMax}");
    Console.WriteLine($"Força: {strength}");
    Console.WriteLine("----------------------------------------\n");
    Console.ResetColor();
  }

  /// <summary>
  /// A method to increase the character's level.
  /// </summary>
  private void LevelUp() {
    // Add 1 level to the character's level and manipule the properties.
    level++;
    exp -= expMax;
    expMax += 5;
    life = 5;
    lifeMax = 5;
    stamina += 5;
    staminaMax += 5;
  }
}