// Libs
using Models;

// Classes
class Game {
  private static string time = "Dia";
  public static int currentDay = 1;
  public static int currentTime = 1;
  public static int timeLimit = 5;
  public static readonly Character character = new();

  public static void Shift() {
    // Display the important things.
    ShowImportantThings();

    // Display the normal options.
    askTheInput:
      ShowChoices();
      Console.Write("\nSua escolha: ");
      string? input = Console.ReadLine();
      Console.WriteLine("----------------------------------------");
      try {
        Controllers.RunChoice.CheckChoice(GetNormalActions(), input);
      } catch (Exception err) {
        Console.Clear();
        Console.WriteLine(err.Message);
        WriteMessage("Escolha inválida", ConsoleColor.DarkRed);

        goto askTheInput;
      }
  }

  /// <summary>
  /// A method to show the important things. As warnings.
  /// </summary>
  private static void ShowImportantThings() {
    // Define the text to print later. * To define the color (Red important, Ylw warn and Grn OK).
    string[] text = new string[3];
    ConsoleColor color = ConsoleColor.DarkYellow;

    // Life Warning.
    if (character.life < character.lifeMax / 10) text[0] = "Sua está fraco e sua visão está esguia... ";

    // Stamina Warning.
    if (character.stamina < character.staminaMax / 10) text[1] = "Você está extremamente cançado!";

    // Print on the console.
    if (text[0] == null && text[1] == null) {
      color = ConsoleColor.DarkGreen;
      text[0] = "Você está se sentindo bem.";
    } else {
      text[3]= "Tente achar uma maneira de se recuperar ou você será derrotado!!!";
    }

    WriteMessage(string.Join("\n", text), color);
  }

  /// <summary>
  /// A method to show the choices (Normal conditions).
  /// </summary>
  private static void ShowChoices() {
    List<string> choices = GetNormalActions();
    string text = $"{time} {currentDay} [{currentTime}/{timeLimit}]\n";
    for (int i = 0; i < choices.Count; i++) {
      string choice = choices[i];
      text += $"{choice}[{i + 1}]\n";
    }
    WriteMessage(text, ConsoleColor.DarkGreen);
    return;
  }

  /// <summary>
  /// A method to get all the choices in a normal conditions (No battle).
  /// </summary>
  /// <returns>
  /// Returns the available choices.
  /// </returns>
  private static List<string> GetNormalActions() {
    // Create the choices
    List<string> choices = new() {
        "Procurar algo",
        "Ver armas",
        "Ver poções",
        "Dormir",
        "Sobre"
    };

    // If day, remove the sleep option.
    if (time == "Dia") choices.RemoveAt(3);
    return choices;
  }

  /// <summary>
  /// A method to check the current time.
  /// If the current time is higher than the timelimit, change the day from the night,
  /// and increase thew day.
  /// </summary>
  public static void UpdateTime() {
    // Increase the current time.
    currentTime++;

    // Check if the current time is higher than the limit.
    if (currentTime < timeLimit) return;

    // Turn the day into night;
    currentTime -= timeLimit;
    if (time == "Dia") {
      time = "Noite";
      return;
    }

    // Increase the time limit and add 1 to day.
    time = "Dia";
    Game.character.stamina = Game.character.staminaMax;
    currentDay++;
    timeLimit+=3;
  }

  /// <summary>
  /// A method to write a message inside the -----.
  /// </summary>
  /// <returns>
  /// Returns
  /// </returns>
  public static void WriteMessage(string message, ConsoleColor color = ConsoleColor.DarkGreen) {
    // Write the message.
    Console.ForegroundColor = color;
    Console.WriteLine("----------------------------------------");
    Console.WriteLine(message);
    Console.WriteLine("----------------------------------------\n");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
  }
}