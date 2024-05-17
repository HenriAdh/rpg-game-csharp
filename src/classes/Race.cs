namespace RPG
{
  public class Human : Character
  {
    public Human(string name) : base(name)
    {
      base.Damage = 10;
      base.Healt = 100;
      base.Speed = 20;
    }
  }

  public class Goblin : Character
  {
    public Goblin(string name) : base(name)
    {
      base.Damage = 5;
      base.Healt = 70;
      base.Speed = 50;
    }
  }

  public class Elf : Character
  {
    public Elf(string name) : base(name)
    {
      base.Damage = 13;
      base.Healt = 90;
      base.Speed = 25;
    }
  }

  public class Dwarf : Character
  {
    public Dwarf(string name) : base(name)
    {
      base.Damage = 17;
      base.Healt = 120;
      base.Speed = 16;
    }
  }

  public class Orc : Character
  {
    public Orc(string name) : base(name)
    {
      base.Damage = 20;
      base.Healt = 120;
      base.Speed = 13;
    }
  }

  public class Wolf : Character
  {
    public Wolf(string name) : base(name)
    {
      base.Damage = 15;
      base.Healt = 70;
      base.Speed = 25;
    }
  }

  public class Gigant : Character
  {
    public Gigant(string name) : base(name)
    {
      base.Damage = 30;
      base.Healt = 200;
      base.Speed = 8;
    }
  }
}