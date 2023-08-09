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
}
