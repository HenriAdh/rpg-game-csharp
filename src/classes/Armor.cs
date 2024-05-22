namespace RPG
{
  public class Armor : Item
  {
    public Armor(string name, int defense, string rarity, int level) : base(name, defense)
    {
      base.Rarity = rarity;
      base.Level = level;
    }

    public override void ShowItem()
    {
      base.ShowItem();
      Console.WriteLine($"Defense: {this.Power}");
    }

    public override void UseFunction(Character character)
    {
      character.EquipArmor(this);
    }
  }
}