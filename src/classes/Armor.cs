namespace RPG
{
  public class Armor
  {
    public int Defense;
    public int Level;
    public string Rarity;
    public string Name;

    public Armor(int defense, int level, string rarity, string name)
    {
      this.Defense = defense;
      this.Level = level;
      this.Rarity = rarity;
      this.Name = name;
    }
  }
}