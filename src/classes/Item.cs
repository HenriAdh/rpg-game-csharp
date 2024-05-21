namespace RPG
{
  public class Item
  {
    public string Name;
    public int Power;

    public Item(string name, int power)
    {
      this.Name = name;
      this.Power = power;
    }

    public virtual void ShowItem()
    {
      Console.Clear();
      Console.WriteLine($"Name: {this.Name}");
      Console.WriteLine($"Power: {this.Power}");
    }
  }
}