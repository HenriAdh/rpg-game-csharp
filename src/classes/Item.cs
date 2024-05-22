namespace RPG
{
  public class Item
  {
    public string Name;
    public int Power;
    public string Rarity;
    public int Level;

    public Item(string name, int power, string rarity, int level)
    {
      this.Name = name;
      this.Power = power;
      this.Rarity = rarity;
      this.Level = level;
    }

    public virtual void ShowItem()
    {
      Console.Clear();
      Console.WriteLine($"Name: {this.Name}");
      Console.WriteLine($"Power: {this.Power}");
      Console.WriteLine($"Rarity: {this.Rarity}");
      Console.WriteLine($"Level: {this.Level}");
    }
  }
}