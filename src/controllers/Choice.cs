// Class
using Models;
using Models.Enemies;
using Models.Items;

namespace Controllers;
public class ChoiceController {
  /// <summary>
  /// A method to check the selected option.
  /// </summary>
  /// Raisenabbke
  public static void CheckNormalChoices(string selectedChoice) {
    // Check all choices.
    Console.Clear();
    switch (selectedChoice) {
      case "Procurar algo":
        OptionSearchThing();
      break;
      case "Ver armas":
        OptionShowWeapons();
      break;
      case "Ver poções":
        OptionShowPotions();
      break;
      case "Dormir":
        OptionSleep();
      break;
      case "Sobre":
        OptionAbout();
      break;
    }
  }

  /// <summary>
  /// A method to be used when the game needs to ask something to the user.
  /// </summary>
  /// <returns>
  /// Returns the selected choice.
  /// </returns>
  public static string SelectChoice(List<string> choices) {
    // Display the options.
    askTheInput:
      ShowChoices(choices);
      Console.Write("\nSua escolha: ");
      string? input = Console.ReadLine();
      Console.WriteLine("----------------------------------------");
      try {
        // Check if the input can be a choice.
        if (input == null) throw new ArgumentNullException(input);
        return choices[int.Parse(input) - 1];
      } catch {
        Console.Clear();
        Game.WriteMessage("Escolha inválida", ConsoleColor.DarkRed);

        goto askTheInput;
      }
  }

  /// <summary>
  /// A method to show the choices (Normal conditions).
  /// </summary>
  private static void ShowChoices(List<string> choices) {
    string text = $"{Game.time} {Game.currentDay} [{Game.currentTime}/{Game.timeLimit}]\n";
    for (int i = 0; i < choices.Count; i++) {
      string choice = choices[i];
      text += $"{choice} [{i + 1}]\n";
    }
    Game.WriteMessage(text, ConsoleColor.DarkGreen);
    return;
  }

  /// <summary>
  /// A method to be ran when the user select search something.
  /// </summary>
  private static void OptionSearchThing() {
    // Define the pathToTake. It'll define if the user'll 
    int pathToTake = new Random().Next(1, 101);

    // Define the player's destiny.
    if (pathToTake <= 40) FindItemController.FindPotion();  // 40%
    else if (pathToTake <= 70) FindItemController.FindWeapon();  // 30%
    else if (pathToTake <= 80) CombatController.StartCombat(new Wolf());  // 10%
    else if (pathToTake <= 90) CombatController.StartCombat(new Slime());  // 10%
    else if (pathToTake <= 99) CombatController.StartCombat(new Golem());  // 9%
    else if (pathToTake == 100) CombatController.StartCombat(new Dragon());  // 1%

    // Update the time from the game.
    Game.UpdateTime();
  }

  /// <summary>
  /// A method to be ran when the user select show weapons.
  /// </summary>
  private static void OptionShowWeapons() {
    Inventory<Weapon> inventory = Game.character.weaponInventory;
    InventoryController.DeleteItemFromInventory(inventory);
  }

  /// <summary>
  /// A method to be ran when the user select show inventory.
  /// </summary>
  private static void OptionShowPotions() {
    // Open the potion inventory interface.
    Inventory<Potion> inventory = Game.character.potionInventory;

    // Define the label to ask the user to select a potion.
    AskUserToSelectPotion:
      Potion? potion = (Potion?)InventoryController.UseItemFromInventory(inventory);

      // Check if the potion is valid.
      if (potion == null) return;

      Console.Clear();
      if (potion is PotionLife) {
        Game.WriteMessage($"Você usou uma [Poção de Vida] que restaurou +{potion.Effect} de sua vida.");
        Game.character.AddLife(potion.Effect);
      } else if (potion is PotionStamina) {
        Game.WriteMessage($"Você usou uma [Poção de Estamina] que restaurou +{potion.Effect} de sua estamina.");
        Game.character.AddStam(potion.Effect);
      }
      goto AskUserToSelectPotion;
  }

  /// <summary>
  /// A method to be ran when the user select sleep.
  /// </summary>
  private static void OptionSleep() {
    Game.currentTime = Game.timeLimit;
    Game.UpdateTime();
    Game.WriteMessage("Você dormiu. A noite virou dia.");
  }

  /// <summary>
  /// A method to be ran when the user select about.
  /// </summary>
  private static void OptionAbout() {
    string text = (
      "Este projeto foi criado em 2020 sendo um dos meus primeiros \"grandes\" projetos.\n"
      + "Então, usando meu carinho, eu refatorei e o atualizei com meus conhecimentos atuais.\n"
      + "Tenha um bom jogo <3."
    );
    Game.WriteMessage(text);
  }
}