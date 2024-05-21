using RPG;
class Program
{
  static void Main()
  {
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

    while (true)
    {
      initialPage.InitialActions();
      string? opt = Console.ReadLine();
      if (opt == "5")
      {
        break;
      }
      else if (opt == "1")
      {
        Character enemy = new Orc("Escala6x1");
        Battle battle = new Battle(hero, enemy);
        battle.InitBattle();
        Console.WriteLine("The battle end!");
        Console.ReadLine();
      }
      else if (opt == "2")
      {
        hero.Show();
      }
    }
    switch (opt)
    {
      case 1:

        break;
      case 2:

        break;
      case 3:
        hero.ShowBag();
        break;
      case 4:
        break;
      default:
        break;
    };
    Console.ReadKey();





    //   Character enemy = new Orc("Ogro");

    //   Console.WriteLine("Hello Warrior, whats your name?");
    //   string? name = Console.ReadLine();
    //   if (name == null || name == "")
    //   {
    //     name = "Player";
    //   }

    //   //Character hero = new Human(name);
    //   Menu menu = new Menu();

    //   hero.Attack(enemy);
    //   Console.WriteLine($"{enemy.Healt}");
    //   Console.ReadKey();

    //   Console.WriteLine($"\n{enemy.Name} found!\n");
    //   Console.ReadKey();

    //   while (true)
    //   {
    //     menu.ShowMenu();
    //     string action = Console.ReadLine() ?? "";
    //     if (action == "5")
    //     {
    //       break;
    //     }
    //     menu.DoAction(action, hero, enemy);
    //   }
  }
}