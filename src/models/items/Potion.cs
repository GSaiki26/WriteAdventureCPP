// Libs
namespace Models.Items;

// Class
public abstract class Potion : IItem {
  public required string Name { get; set;}
  public int Effect { get; set;}

  /// <summary>
  /// A method to return the name of the item using his stats.
  /// </summary>
  /// <returns>
  /// Returns the name from the item.
  /// </returns>
  public string GetName() {
      return $"[{Name}] +{Effect}";
  }
}
