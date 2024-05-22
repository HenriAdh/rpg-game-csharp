namespace RPG
{
  public class Weapon : Item
  {
    public int Range;

    public Weapon(string name, int damage) : base(name, damage) { }

    public override void ShowItem()
    {
      base.ShowItem();
      Console.WriteLine($"Range: {this.Range}");
    }

    public override void UseFunction(Character character)
    {
      character.EquipWeapon(this);
    }
  }

  public class Sword : Weapon
  {
    public Sword(string name, int damage, int level, string rarity) : base(name, damage)
    {
      base.Range = 2;
      base.Level = level;
      base.Rarity = rarity;
    }
  }

  public class Axe : Weapon
  {
    public Axe(string name, int damage, int level, string rarity) : base(name, damage)
    {
      base.Range = 3;
      base.Level = level;
      base.Rarity = rarity;
    }
  }

  public class Hammer : Weapon
  {
    public Hammer(string name, int damage, int level, string rarity) : base(name, damage)
    {
      base.Range = 3;
      base.Level = level;
      base.Rarity = rarity;
    }
  }

  public class Arch : Weapon
  {
    public Arch(string name, int damage, int level, string rarity) : base(name, damage)
    {
      base.Range = 12;
      base.Level = level;
      base.Rarity = rarity;
    }
  }

  public class Dagger : Weapon
  {
    public Dagger(string name, int damage, int level, string rarity) : base(name, damage)
    {
      base.Range = 1;
      base.Level = level;
      base.Rarity = rarity;
    }
  }

  public class Stave : Weapon
  {
    public Stave(string name, int damage, int level, string rarity) : base(name, damage)
    {
      base.Range = 10;
      base.Level = level;
      base.Rarity = rarity;
    }
  }

  public class Mandolin : Weapon
  {
    public Mandolin(string name, int damage, int level, string rarity) : base(name, damage)
    {
      base.Range = 8;
      base.Level = level;
      base.Rarity = rarity;
    }
  }
}