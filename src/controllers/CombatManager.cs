// Libs
using Models.Enemies;

namespace Controllers;

// Class
class CombatManager {
  /// <summary>
  /// A method to start a combat with the provided enemy.
  /// </summary>
  public static void StartCombat(Enemy enemy) {
    // Define the combat loop.
    bool onCombat = true;
    while (onCombat) {
      // Show the combat stats on screen.
      ShowCombat(enemy);

      // Get the user choice.
      int choice = GetUserChoice();

      // Do the combat things.
    }

    // The combat has ended. Clear the console and add the experience to the player.
    Console.Clear();
    Game.character.AddExp(enemy.Exp);
  }

  /// <summary>
  /// A method to get the user choice on combat.
  /// </summary>
  /// <returns>
  /// Returns the user's choice.
  /// </returns>
  public static int GetUserChoice() {
  }

  public static void ShowChoices() {
    
  }
    // Add all the weapons to the choices.
    List<string> choices = new() {
      "Socar"
    };
    for (int i = 0; i < Game.character.weaponInventory.content.Count; i++) {
      choices.Add(Game.character.weaponInventory.content[i].GetName());
    }

    // Show
  }

  /// <summary>
  /// A method to show the current combat informations.
  /// </summary>
  private static void ShowCombat(Enemy enemy) {
    // Write on the screen.
    string text = (
      $"[{enemy.Name}]\n"
      +$"Dano: {enemy.Damage}"
      +$"Vida: {enemy.Life}"
    );

    Game.WriteMessage(text, ConsoleColor.DarkRed);
  }
}