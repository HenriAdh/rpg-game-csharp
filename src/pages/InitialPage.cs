namespace RPG
{
  public class InitialPage
  {
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
        Console.WriteLine($"\nWhats your classe?");
        Console.WriteLine($"--------------------");
        Console.WriteLine($"[1] Knight");
        Console.WriteLine($"[2] Archer");
        Console.WriteLine($"[3] Mage");
        Console.WriteLine($"[4] Assassin");
        Console.WriteLine($"[5] Healer");
        Console.WriteLine($"[6] Paladin");
        Console.WriteLine($"[7] Barbarian");
        Console.WriteLine($"[8] Bard");
        Console.WriteLine($"");

        race = Console.ReadLine();
        if (race == null || race == "")
        {
          Console.Write("\nPlease, choose an valid option.");
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
    public void InitialActions()
    {
      Console.Clear();
      Console.WriteLine($"        Menu        ");
      Console.WriteLine($"--------------------");
      Console.WriteLine($"[1] Start Adventure ");
      Console.WriteLine($"[2] Stats           ");
      Console.WriteLine($"[3] Bag             ");
      Console.WriteLine($"[4] Store           ");
      Console.WriteLine($"[5] Exit            ");
      Console.WriteLine("");
    }
  }
}