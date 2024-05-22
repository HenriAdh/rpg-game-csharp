namespace RPG
{
  public class Human : Character
  {
    public Human(string name) : base(name)
    {
      base.Bag = new Item[10];
      base.Damage = 10;
      base.Healt = 100;
      base.Speed = 20;
      base.BaseDamage = 10;
      base.BaseHealt = 100;
      base.BaseSpeed = 20;
      Item sword = new Weapon("Sword", 10, 2, "Silver", 1);
      Item silver_armor = new Armor("Silver Armor", 5, "Silver", 1);
      base.AddItemToBag(sword);
      base.AddItemToBag(silver_armor);
    }
  }

  public class Goblin : Character
  {
    public Goblin(string name) : base(name)
    {
      base.Damage = 7;
      base.Healt = 70;
      base.Speed = 50;
      base.BaseDamage = 7;
      base.BaseHealt = 70;
      base.BaseSpeed = 50;
      Item knife = new Weapon("Knife", 10, 1, "Silver", 1);
      Item boar_skin = new Armor("Boar Skin", 2, "Silver", 1);
      base.AddItemToBag(knife);
      base.AddItemToBag(boar_skin);
    }
  }

  public class Elf : Character
  {
    public Elf(string name) : base(name)
    {
      base.Damage = 13;
      base.Healt = 90;
      base.Speed = 25;
      base.BaseDamage = 13;
      base.BaseHealt = 90;
      base.BaseSpeed = 25;
      Item bow = new Weapon("Bow", 10, 8, "Silver", 1);
      Item enchanted_cloak = new Armor("Enchanted Cloak", 3, "Silver", 1);
      base.AddItemToBag(bow);
      base.AddItemToBag(enchanted_cloak);
    }
  }

  public class Dwarf : Character
  {
    public Dwarf(string name) : base(name)
    {
      base.Damage = 17;
      base.Healt = 120;
      base.Speed = 16;
      base.BaseDamage = 17;
      base.BaseHealt = 120;
      base.BaseSpeed = 16;
      Item hammer = new Weapon("Hammer", 10, 3, "Silver", 1);
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
      base.BaseDamage = 20;
      base.BaseHealt = 120;
      base.BaseSpeed = 13;
      Item war_hammer = new Weapon("War Hammer", 10, 3, "Silver", 1);
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
      base.BaseDamage = 15;
      base.BaseHealt = 70;
      base.BaseSpeed = 25;
      Item claws = new Weapon("Claws", 10, 3, "Silver", 1);
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
      base.BaseDamage = 30;
      base.BaseHealt = 200;
      base.BaseSpeed = 8;
      Item hand = new Weapon("Hand", 10, 3, "Silver", 1);
      base.AddItemToBag(hand);
    }
  }
}