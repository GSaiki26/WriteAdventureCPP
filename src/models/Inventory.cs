// Libs
using Models.Items;
namespace Models;

// Class
public class Inventory<IItem> {
  public readonly List<IItem> content = new();
  private readonly int size;

  public Inventory(int size) {
    this.size = size;
  }

  /// <summary>
  /// A method to add some item in the inventory.
  /// </summary>
  /// <Returns>
  /// Returns true if the item was successfully inserted in the inventory.
  /// Returns false if the item was not inserted in the inventory. Due to full slots.
  /// </Returns>
  public bool AddItem(IItem item) {
    // Add the item to the bag.
    if ( content.Count == size ) return false;
    content.Add(item);
    return true;
  }

  /// <summary>
  /// A method to remove some item from the Inventory.
  /// </summary>
  public void RemoveItem(int index) {
    // Remove the index from the inventory and "pop" the item from the inventory.
    if (content.Count <= index) return;
    content.RemoveAt(index);
  }
}
