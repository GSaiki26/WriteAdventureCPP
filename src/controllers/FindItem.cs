// Libs
using Models.Items;

namespace Controllers;

// Class
class FindItem {
  /// <summary>
  /// A method to define the potion that the player'll find.
  /// </summary>
  public static void FindPotion() {
    // Define the potion.
    Potion? potion;
    if (new Random().Next(0, 4) < 3) potion = new PotionStamina();
    else potion = new PotionLife();

    // Try to add the potion to the inventory.
    string text = $"Você encontrou uma {potion.GetName()}. ";
    if (!Game.character.potionInventory.AddItem(potion)) {
      text += "Porém não foi possível adicioná-la a sua bolsa, pois está cheia.";
    } else {
      text += "Cheque seu inventário para usá-la.";
    }
    
    Game.WriteMessage(text);
  }

  /// <summary>
  /// A method to define the weapon that the player'll find.
  /// </summary>
  public static void FindWeapon() {
    // Define the weapon.
    Weapon? weapon;
    if (new Random().Next(0, 4) <= 1) weapon = new WeaponSword();
    else weapon = new WeaponAxe();

    // Try to add the weapon to the inventory.
    string text = $"Você encontrou uma nova arma: {weapon.GetName()}.";
    if (!Game.character.weaponInventory.AddItem(weapon)) {
      text += "\nPorém não foi possível adicioná-la a sua bolsa, pois está cheia.";
    } else {
      text += "Cheque seu inventário para usá-la.";
    }
    
    Game.WriteMessage(text);
  }
}