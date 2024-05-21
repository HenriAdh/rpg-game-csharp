namespace RPG
{
  public class Human : Character
  {
    public Human(string name) : base(name)
    {
      base.Damage = 10;
      base.Healt = 100;
      base.Speed = 20;
      Item sword = new Weapon("Sword", 10, 3);
      base.AddItemToBag(sword);
    }
  }

  public class Goblin : Character
  {
    public Goblin(string name) : base(name)
    {
      base.Damage = 7;
      base.Healt = 70;
      base.Speed = 50;
      Item knife = new Weapon("Knife", 10, 3);
      base.AddItemToBag(knife);
    }
  }

  public class Elf : Character
  {
    public Elf(string name) : base(name)
    {
      base.Damage = 13;
      base.Healt = 90;
      base.Speed = 25;
      Item bow = new Weapon("Bow", 10, 3);
      base.AddItemToBag(bow);
    }
  }

  public class Dwarf : Character
  {
    public Dwarf(string name) : base(name)
    {
      base.Damage = 17;
      base.Healt = 120;
      base.Speed = 16;
      Item hammer = new Weapon("Hammer", 10, 3);
      base.AddItemToBag(hammer);
    }
  }

  public class Orc : Character
  {
    public Orc(string name) : base(name)
    {
      base.Damage = 20;
      base.Healt = 120;
      base.Speed = 13;
      Item war_hammer = new Weapon("War Hammer", 10, 3);
      base.AddItemToBag(war_hammer);
    }
  }

  public class Wolf : Character
  {
    public Wolf(string name) : base(name)
    {
      base.Damage = 15;
      base.Healt = 70;
      base.Speed = 25;
      Item claws = new Weapon("Claws", 10, 3);
      base.AddItemToBag(claws);
    }
  }

  public class Gigant : Character
  {
    public Gigant(string name) : base(name)
    {
      base.Damage = 30;
      base.Healt = 200;
      base.Speed = 8;
      Item hand = new Weapon("Hand", 10, 3);
      base.AddItemToBag(hand);
    }
  }
}