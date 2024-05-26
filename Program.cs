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
      "1" => new Knight(infs_player[0]),
      "2" => new Archer(infs_player[0]),
      "3" => new Mage(infs_player[0]),
      "4" => new Assassin(infs_player[0]),
      "5" => new Healer(infs_player[0]),
      "6" => new Paladin(infs_player[0]),
      "7" => new Barbarian(infs_player[0]),
      "8" => new Bard(infs_player[0]),
      _ => new Knight(infs_player[0]),
    };
    Store store = new Store(hero);

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
        store = new Store(hero);
        Character enemy = GenerateEnemy(hero);
        Battle battle = new Battle(hero, enemy);
        battle.InitBattle();
        string winner = battle.CheckWinner(hero, enemy);
        if (winner == "enemy")
        {
          Console.WriteLine($"Game Over, you are died.");
          Console.WriteLine("\nDo you wanna play again? (y/n)");
          Console.WriteLine();
          string? play_again = Console.ReadLine();
          if (play_again == "Y" || play_again == "y")
          {
            Console.Write($"\nLet's go, {hero.Name}!");
            string newName = hero.Name;

            hero = infs_player[1] switch
            {
              "1" => new Knight(newName),
              "2" => new Archer(newName),
              "3" => new Mage(newName),
              "4" => new Assassin(newName),
              "5" => new Healer(newName),
              "6" => new Paladin(newName),
              "7" => new Barbarian(newName),
              "8" => new Bard(newName),
              _ => new Knight(newName),
            };
          }
          else
          {
            Main();
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
          int experience = (enemy.Level == 0 ? 1 : enemy.Level) * 5;
          hero.Experience += experience;
          if (hero.WeaponEquiped != null) hero.WeaponEquiped.Level++;
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
        Console.ReadKey();
      }
      else if (opt == "3")
      {
        hero.ShowBag();
      }
      else if (opt == "4")
      {
        store.ShowStore(hero);
      }
      else
      {
        Console.WriteLine("\nPlease, choose an valid option.");
        Console.ReadKey();
      }
    }
  }

  static Character GenerateEnemy(Character hero)
  {
    Random random = new();
    int rdNumber = random.Next(0, 8) + 1;

    Names names = new();
    string newName = names.RandName();

    Character enemy = rdNumber switch
    {
      1 => new Knight(newName),
      2 => new Archer(newName),
      3 => new Mage(newName),
      4 => new Assassin(newName),
      5 => new Healer(newName),
      6 => new Paladin(newName),
      7 => new Barbarian(newName),
      8 => new Bard(newName),
      _ => new Knight(newName),
    };

    enemy.BaseHealt += hero.Level * enemy.BaseHealt / 15 / 10;
    enemy.Healt = enemy.BaseHealt;

    enemy.BaseDamage += hero.Level * enemy.BaseDamage / 15 / 10;
    enemy.Damage = enemy.BaseDamage;

    enemy.BaseSpeed += hero.Level * enemy.BaseSpeed / 15 / 10;
    enemy.Speed = enemy.BaseSpeed;

    enemy.Coins = new Random().Next(4, (hero.Level + 1) * 5);

    return enemy;
  }
}