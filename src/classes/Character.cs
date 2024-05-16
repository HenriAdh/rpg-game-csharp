namespace RPG
{
  public class Character
  {
    public string Name;
    public int Healt;
    public int Damage;
    public string[] Bag = { };

    public Character(string name, int healt, int damage)
    {
      Name = name;
      Healt = healt;
      Damage = damage;
    }

    public void Show()
    {
      Console.WriteLine();
      Console.WriteLine($"NAME: {Name}");
      Console.WriteLine($"HP: {Healt}");
      Console.WriteLine($"DAMAGE: {Damage}");
    }

    public void ShowBag()
    {
      string itens = "";
      for (int x = 0; x < Bag.Length; x++)
      {
        itens += Bag[x];
      }
      Console.WriteLine($"Itens in the bag: {itens}");
    }

    public void Hit(int damage)
    {
      Console.WriteLine($"{Name} was hitted, lost {damage} poits of healt.");
      Healt -= damage;
      if (Healt < 0)
      {
        Healt = 0;
      }
    }
  }
}