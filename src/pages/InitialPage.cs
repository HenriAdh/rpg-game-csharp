namespace RPG
{
  public class InitialPage
  {
    static bool ValidateOption(string? action)
    {
      return action switch
      {
        "1" => true,
        "2" => true,
        "3" => true,
        "4" => true,
        "5" => true,
        _ => false,
      };
    }
    public string[] NewPlayer()
    {
      string[] new_player_infs = new string[2];
      string? race;
      Console.WriteLine($"Welcome warrior, whats your name?");
      string? name = Console.ReadLine();
      if (name == null || name == "")
      {
        name = "Player";
      }
      new_player_infs[0] = name;
      while (true)
      {
        Console.Clear();
        Console.WriteLine($"Hello {name}, nice to meet you!");
        Console.WriteLine($"\nWhats your race?");
        Console.WriteLine($"    Name    | Healt | Damage | Speed");
        Console.WriteLine($"------------------------------------");
        Console.WriteLine($"[1] Human   | 100   | 10     | 20   ");
        Console.WriteLine($"[2] Elf     | 90    | 13     | 25   ");
        Console.WriteLine($"[3] Dwarf   | 120   | 17     | 16   ");
        Console.WriteLine($"[4] Orc     | 120   | 20     | 20   ");
        Console.WriteLine($"[5] Goblin  | 70    | 7      | 50   ");
        Console.WriteLine($"\n");
        race = Console.ReadLine();
        if (race == null || race == "")
        {
          Console.Write("\nInvalid option!");
          Console.ReadKey();
        }
        else
        {
          new_player_infs[1] = race;
          return new_player_infs;
        }
      }
    }
    // Se apagar é gay o
    public int InitialActions()
    {
      string? action;
      while (true)
      {
        Console.Clear();
        Console.WriteLine($"[1] Start Adventure ");
        Console.WriteLine($"[2] Stats           ");
        Console.WriteLine($"[3] Bag             ");
        Console.WriteLine($"[4] Sla             ");
        Console.WriteLine($"[5] Exit            ");
        Console.WriteLine("\n");
        action = Console.ReadLine();
        bool is_valid = ValidateOption(action);
        if (is_valid)
        {
          break;
        }
        else
        {
          Console.WriteLine("\nInvalid Option!");
          Console.ReadKey();
        }
      }
      int opt = Convert.ToInt32(action);
      return opt;
    }
  }
}