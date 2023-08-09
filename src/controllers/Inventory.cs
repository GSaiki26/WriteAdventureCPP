// Libs
using Models;
using Models.Items;

namespace Controllers;

// Class
public class InventoryController {
  /// <summary>
  /// A method to select some item from the inventory.
  /// </summary>
  /// <returns>
  /// Returns the selected item.
  /// </returns>
  public static IItem? UseItemFromInventory<T>(Inventory<T> inventory) where T : class, IItem {
    // Check if the inventory is valid.
    if (!IsInventoryValid(inventory)) return null;

    // Get the choice and check if the the user wants to exit the inventory.
    int? choice = SelectItemFromInventory(inventory);
    if (!choice.HasValue) {
      Console.Clear();
      return null;
    }

    // Remove the item from the inventory and go to the label. It'll ask the user to select other item.
    IItem selectedItem = inventory.content[choice.Value];
    inventory.RemoveItem(choice.Value);
    return selectedItem;
  } 

  /// <summary>
  /// A method to delete some items from the inventory.
  /// </summary>
  public static void DeleteItemFromInventory<T>(Inventory<T> inventory) where T : class, IItem {
    // Check if the inventory is valid.
    if (!IsInventoryValid(inventory)) return;

    // Get the choice and check if the the user wants to exit the inventory.
    SelectSomeItemFromInventory:
    int? choice = SelectItemFromInventory(inventory);
    if (!choice.HasValue) {
      Console.Clear();
      return;
    }

    // Remove the item from the inventory and go to the label. It'll ask the user to select other item.
    inventory.RemoveItem(choice.Value);
    goto SelectSomeItemFromInventory;
  }

  /// <summary>
  /// A method to just show the content from the inventory.
  /// </summary>
  public static void OpenInventory<T>(Inventory<T> inventory) where T : class, IItem {
    // Check if the inventory is valid.
    if (!IsInventoryValid(inventory)) return;

    // Show the inventory content.
    ShowContent(inventory.content);
  }

  /// <summary>
  /// A method to open the bag interface. It must select some item or select exit.
  /// </summary>
  /// <returns>
  /// Returns the selected index.
  /// </returns>
  private static int? SelectItemFromInventory<T>(Inventory<T> inventory) where T : class, IItem {
    // Show the inventory content.
    ShowContent(inventory.content, true);

    // Try to get some selected item using the user's input.
    GetUserInput:
      Console.Write("Sua opção: ");
      try {
        int choice = int.Parse(Console.ReadLine()!);
        // Check if the choice is valid.
        if (choice <= 0 || choice > inventory.content.Count + 1) throw new Exception("Invalid choice.");
        if (choice == inventory.content.Count + 1) return null;
        return choice - 1;
      } catch {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Opção inválida.");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        goto GetUserInput;
      }
  }

  /// <summary>
  /// A method to show the content from the inventory.
  /// </summary>
  private static void ShowContent<T>(List<T> content, bool showExitButton = true) where T : class, IItem {
    // Add all the items from the inventory to the string, so that can be printed with their index.
    string text = "";
    for (int i = 0; i < content.Count; i++) {
      text += $"{content[i].Name} [{i + 1}]\n";
    }

    // if showExitButton, add the exit option and then write on the screen.
    if (showExitButton) text += $"Sair [{content.Count + 1}]";
    Game.WriteMessage(text, ConsoleColor.DarkMagenta);
  }

  /// <summary>
  /// A method to check if the inventory is valid.
  /// </summary>
  /// <returns>
  /// Returns if the inventory is valid.
  /// </returns>
  private static bool IsInventoryValid<T>(Inventory<T> inventory) {
    // Check if the inventory has some content.
    if (inventory.content.Count == 0) {
      Game.WriteMessage("A bolsa está vazia.", ConsoleColor.DarkYellow);
      return false;
    }

    return true;
  }
}
