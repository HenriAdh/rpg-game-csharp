using RPG;
class Program
{
  static void Main()
  {
    Character enemy = new Orc("Ogro");

    Console.WriteLine("Hello Warrior, whats your name?");
    string? name = Console.ReadLine();
    if (name == null || name == "")
    {
      name = "Player";
    }

    Character hero = new Human(name);
    Menu menu = new Menu();

    hero.Attack(enemy);
    Console.WriteLine($"{enemy.Healt}");
    Console.ReadKey();

    Console.WriteLine($"\n{enemy.Name} found!\n");
    Console.ReadKey();

    while (true)
    {
      menu.ShowMenu();
      string action = Console.ReadLine() ?? "";
      if (action == "5")
      {
        break;
      }
      menu.DoAction(action, hero, enemy);
    }
  }
}