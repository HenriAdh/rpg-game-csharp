using System.Runtime.CompilerServices;
using RPG;
class Program
{
  static void Main()
  {
    Console.Clear();
    InitialPage initialPage = new InitialPage();
    string[] infs_player = initialPage.NewPlayer();
    Character hero = infs_player[1] switch
    {
      "1" => new Human(infs_player[0]),
      "2" => new Elf(infs_player[0]),
      "3" => new Dwarf(infs_player[0]),
      "4" => new Orc(infs_player[0]),
      "5" => new Goblin(infs_player[0]),
      _ => new Human(infs_player[0]),
    };

    Menu(initialPage, hero, infs_player[1]);
  }

  public static void Menu(InitialPage initialPage, Character hero, string race)
  {
    while (true)
    {
      initialPage.InitialActions();

      string? opt = Console.ReadLine();

      if (opt == "5")
      {
        Console.WriteLine("\nSee you, warrior!");
        Console.ReadKey();
        return;
      }
      else if (opt == "1")
      {
        Character enemy = new Orc("Escala6x1");
        Battle battle = new Battle(hero, enemy);
        battle.InitBattle();
        if (hero.Healt <= 0)
        {
          Console.WriteLine($"Game Over, you are died.");
          Console.WriteLine("\nDo you wanna play again? (y/n)");
          Console.WriteLine();
          string? play_again = Console.ReadLine();
          if (play_again == "Y" || play_again == "y")
          {
            Console.Write($"\nLet's go, {hero.Name}!");
            string newName = hero.Name;

            hero = race switch
            {
              "1" => new Human(newName),
              "2" => new Elf(newName),
              "3" => new Dwarf(newName),
              "4" => new Orc(newName),
              "5" => new Goblin(newName),
              _ => new Human(newName),
            };
          }
          else
          {
            return;
          }
        }
        else
        {
          Console.ReadKey();
          Console.Clear();
          Console.WriteLine($"You Defeat {enemy.Name}!");
          Console.ReadKey();
          hero.Healt = hero.BaseHealt;
          Console.Clear();
          Console.WriteLine($"You rest and recovery your energy. Points of Healt: {hero.Healt}");
          Console.ReadKey();
          int experience = enemy.Level * 5;
          hero.Experience += experience;
          Console.WriteLine($"After this battle, you learn more and have gained {experience} points of exeperience. {hero.Experience}/{hero.ExperienceToNextLevel}");
          Console.ReadKey();
          if (hero.Experience >= hero.ExperienceToNextLevel)
          {
            hero.LevelUp();
          }
          hero.Coins += enemy.Coins;
          Console.WriteLine($"{enemy.Name} dropped {enemy.Coins} coins. Now {hero.Name} have {hero.Coins} coins.");
        }
      }
      else if (opt == "2")
      {
        hero.Show();
      }
      else if (opt == "3")
      {
        hero.ShowBag();
      }
      else if (opt == "4")
      {
        Console.WriteLine("Comming soon!");
      }
      else
      {
        Console.WriteLine("\nPlease, choose an valid option.");
      }
      Console.ReadKey();
    }
  }
}