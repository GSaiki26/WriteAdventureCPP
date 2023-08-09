// Libs
namespace Models.Items;

// Class
public abstract class Weapon : IItem {
  public required string Name { get; set; }
  public int? Damage { get; set; }
  public int? Durability { get; set; }
  public int? DurabilityMax { get; set; }
  public int? Stamina { get; set; }

  /// <summary>
  /// A method to return the name of the item using his stats.
  /// </summary>
  /// <returns>
  /// Returns the name from the item.
  /// </returns>
  public string GetName() {
    return $"{Name} Dano: {Damage} | Estamina: {Stamina} [{Durability}/{DurabilityMax}]";
  }

  /// <summary>
  /// A method to remove the durability from the weapon. Checks if the weapon is broken.
  /// </summary>
  /// <returns>
  /// Returns if the weapon is broken.
  /// </returns>
  public bool RemoveDurability() {
    // Remove -1 from durability if weapon is not broken.
    if (Durability == 0) return true;

    Durability--;
    return false;
  }
}
