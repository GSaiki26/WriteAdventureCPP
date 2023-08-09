// Libs
using Models.Enemies;
using Models.Items;

namespace Controllers;

// Class
class CombatController {
  /// <summary>
  /// A method to start a combat with the provided enemy.
  /// </summary>
  public static void StartCombat(Enemy enemy) {
    // Define the combat loop.
    bool onCombat = true;
    while (onCombat) {
      // Show the combat stats on screen.
      ShowCombat(enemy);

      // User's turn.
      // Ask the user the selected option.
      List<string> choices = GetChoices();
      string selectedAction = ChoiceController.SelectChoice(choices);
      Console.Clear();

      // Open inventory option.
      if (selectedAction == "Abrir inventário") {
        InventoryController.UseItemFromInventory(Game.character.potionInventory);
        continue;
      }

      // Attack options.
      int[] attackMove = GetAttackMove(selectedAction);
      string text = $"Você o causou -{attackMove[0]} de dano, porém perdeu -{attackMove[1]} de estamina.";
      Game.WriteMessage(text);

      enemy.Life -= attackMove[0];
      Game.character.stamina -= attackMove[1];

      if (enemy.Life <= 0) {
        Game.WriteMessage($"Você venceu ganhando +{enemy.Exp} de exp.", ConsoleColor.Yellow);
        onCombat = false;
        continue;
      }

      // Defending.
      Game.WriteMessage($"O {enemy.Name} atacou causando -{enemy.Damage} de vida.", ConsoleColor.DarkRed);
      Game.character.life -= enemy.Damage;
      if (Game.character.life <= 0) {
        Game.WriteMessage("Sua barra de vida está vazia. Você perdeu.");
        Environment.Exit(0);
      }
    }

    // The combat has ended. Clear the console and add the experience to the player.
    Console.Clear();
    Game.character.AddExp(enemy.Exp);
  }

  /// <summary>
  /// A method to define the damage[0] and stamina[1] that'll be used on the combat.
  /// </summary>
  /// <returns>
  /// Returns the damage[0] and the stamina[1].
  /// </returns>
  private static int[] GetAttackMove(string selectedAction) {
    // Define the damage and the needed stamina to do a normal punch.
    int dmg = Game.character.strength;
    int neededStamina = Game.character.staminaMax / 12;

    if (selectedAction == "Socar") return new int[2] {dmg, neededStamina};

    // Get the weapon that the user has selected.
    int weaponIndex = 0;
    for (int i = 0; i < Game.character.weaponInventory.content.Count; i++) {
      if (Game.character.weaponInventory.content[i].GetName() == selectedAction) weaponIndex = i;
    }

    // Check if the weapon is broken.
    bool isWeaponBroken = Game.character.weaponInventory.content[weaponIndex].RemoveDurability();
    if (isWeaponBroken) {
      Game.WriteMessage(
        "Você tenta sacar sua arma, porém ela está destruida. Você o da um soco.",
        ConsoleColor.DarkYellow);
      return new int[2] {dmg, neededStamina};
    }

    // Try to use the weapon.
    dmg = (int)Game.character.weaponInventory.content[weaponIndex].Damage!;
    neededStamina = (int)Game.character.weaponInventory.content[weaponIndex].Stamina!;

    if (neededStamina > Game.character.stamina) {
      Game.WriteMessage("Você saca sua arma, porém está cansado demais para usá-la, o que acaba lhe custando seu turno...", ConsoleColor.DarkRed);
      return new int[2] {0, 0};
    }

    return new int[2] {dmg, neededStamina};
  }

  /// <summary>
  /// A method to get all the choices that the user can do.
  /// </summary>
  /// <returns>
  /// Returns the list of choices.
  /// </returns>
  private static List<string> GetChoices() {
    // Add all the weapons to the choices.
    List<string> choices = new() {
      "Socar"
    };
    for (int i = 0; i < Game.character.weaponInventory.content.Count; i++) {
      choices.Add(Game.character.weaponInventory.content[i].GetName());
    }

    // Add the inventory options.
    choices.Add("Abrir inventário");
    return choices;
  }

  /// <summary>
  /// A method to show the current combat informations.
  /// </summary>
  private static void ShowCombat(Enemy enemy) {
    // Write on the screen.
    string text = (
      $"[{enemy.Name}]\n"
      +$"Dano: {enemy.Damage}\n"
      +$"Vida: {enemy.Life}\n"
    );

    Game.WriteMessage(text, ConsoleColor.DarkRed);
  }
}