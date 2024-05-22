namespace RPG
{
  public class Weapon : Item
  {
    public int Range;

    public Weapon(string name, int damage, int range, string rarity, int level) : base(name, damage, rarity, level)
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