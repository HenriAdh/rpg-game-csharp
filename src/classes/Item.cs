namespace RPG
{
  public abstract class Item
  {
    public string Name;
    public int Power;
    public string Rarity;
    public int Level;

    public Item(string name, int power)
    {
      this.Name = name;
      this.Power = power;
      this.Rarity = "Comun";
    }

    public virtual void ShowItem()
    {
      Console.Clear();
      Console.WriteLine($"Name: {this.Name}");
      Console.WriteLine($"Level: {this.Level}");
      Console.WriteLine($"Rarity: {this.Rarity}");
    }

    public virtual void UseFunction(Character character) { }
  }
}