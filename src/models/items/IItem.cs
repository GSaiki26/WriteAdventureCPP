// Interfaces
namespace Models.Items;
public interface IItem {
  string Name { get; set;}

  public string GetName();
}