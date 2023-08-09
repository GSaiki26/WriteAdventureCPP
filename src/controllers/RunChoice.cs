// Class
using Models;
using Models.Enemies;
using Models.Items;

namespace Controllers;
public class RunChoice {
  /// <summary>
  /// A method to check the selected option.
  /// </summary>
  /// Raisenabbke
  public static void CheckChoice(List<string> choices, string? input) {
    // Check if the input can be a choice.
    if (input == null) throw new ArgumentNullException(input);
    string selectedChoice = choices[int.Parse(input) - 1];

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
  /// A method to be ran when the user select search something.
  /// </summary>
  private static void OptionSearchThing() {
    // Define the pathToTake. It'll define if the user'll 
    int pathToTake = new Random().Next(1, 101);

    // Define the player's destiny.
    if (pathToTake <= 30) FindItem.FindPotion();  // 30%
    if (pathToTake <= 50) FindItem.FindWeapon();  // 20%
    if (pathToTake <= 70) CombatManager.StartCombat(new Wolf());  // 20%
    if (pathToTake <= 90) CombatManager.StartCombat(new Slime());  // 20%
    if (pathToTake <= 99) CombatManager.StartCombat(new Golem());  // 9%
    if (pathToTake == 100) CombatManager.StartCombat(new Dragon());  // 1%

    // Update the time from the game.
    Game.UpdateTime();
  }

  /// <summary>
  /// A method to be ran when the user select show weapons.
  /// </summary>
  private static void OptionShowWeapons() {
    Inventory<IItem> inventory = Game.character.weaponInventory;
    InventoryManager.DeleteItemFromInventory(inventory);
  }

  /// <summary>
  /// A method to be ran when the user select show inventory.
  /// </summary>
  private static void OptionShowPotions() {
    // Open the potion inventory interface.
    Inventory<IItem> inventory = Game.character.potionInventory;

    // Define the label to ask the user to select a potion.
    AskUserToSelectPotion:
      Potion? potion = (Potion?)InventoryManager.UseItemFromInventory(inventory);

      // Check if the potion is valid.
      if (potion == null) return;

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