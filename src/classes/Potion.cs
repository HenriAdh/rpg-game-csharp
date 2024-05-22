namespace RPG
{
  public class Potion : Item
  {
    public int Amount;
    public Potion(string name, int power, int amount) : base(name, power)
    {
      this.Amount = amount;
    }

    public override void ShowItem()
    {
      base.ShowItem();
      Console.WriteLine($"Amount: {this.Amount}");
    }

    public void SumItem(int amount)
    {
      this.Amount += amount;
    }
  }

  public class Heal : Potion
  {
    public Heal(string name, int power, int amount, string rarity, int level) : base(name, power, amount)
    {
      base.Rarity = rarity;
      base.Level = level;
    }

    public override void ShowItem()
    {
      base.ShowItem();
      Console.WriteLine($"Heals: {this.Power}");
    }

    public override void UseFunction(Character character)
    {
      character.RecoveryHealt(this);
    }
  }
}