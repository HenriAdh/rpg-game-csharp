namespace RPG
{
  public class Weapon : Item
  {
    public int Range;

    public Weapon(string name, int damage, int range) : base(name, damage)
    {
      this.Range = range;
    }

    public override void ShowItem()
    {
      base.ShowItem();
      Console.WriteLine($"Range: {this.Power}");
    }
  }
}