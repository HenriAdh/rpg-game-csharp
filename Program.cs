using RPG;
class Program
{
  static void Main()
  {
    Character enemy = new Character("Ogro", 150, 5);

    Console.WriteLine("Hello Warrior, whats your name?");
    string? name = Console.ReadLine();
    if (name == null || name == "")
    {
      name = "Player";
    }

    Character hero = new Character(name, 100, 10);
    Menu menu = new Menu();

    hero.Show();

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
      Console.ReadKey();
    }
  }
}