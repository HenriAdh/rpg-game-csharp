using System.Collections;
using System.Data.Common;

namespace RPG
{
  public class Character
  {
    public string Name;
    public int Healt;
    public int Damage;
    public int Speed;
    public string[] Bag = { };
    private int LimitBag = 10;
    public Weapon? WeaponEquiped;

    public Character(string name)
    {
      Name = name;
    }

    public void Show()
    {
      Console.WriteLine();
      Console.WriteLine($"NAME: {Name}");
      Console.WriteLine($"HP: {Healt}");
      Console.WriteLine($"DAMAGE: {Damage}");
      Console.WriteLine($"SPEED: {Speed}");
      Console.WriteLine($"BAG: {Bag.Length}/{LimitBag}");
    }

    public void ShowBag()
    {
      string itens = "";
      for (int x = 0; x < Bag.Length; x++)
      {
        itens += Bag[x];
      }
      Console.WriteLine($"Itens in the bag: {itens}");
    }

    public void EquipWeapon(Weapon weapon)
    {
      this.WeaponEquiped = weapon;
      Console.WriteLine($"{this.Name} equipped a weapon {weapon.Name}.");
    }

    public void LostHealt(int damage)
    {
      Console.WriteLine($"{Name} was hitted, lost {damage} poits of healt.");
      Healt -= damage;
      if (Healt < 0)
      {
        Healt = 0;
      }
    }

    public void Attack(Character enemy)
    {
      int damage = this.Damage;
      if (!(this.WeaponEquiped == null))
      {
        damage = this.WeaponEquiped.Damage;
      }
      enemy.Healt -= damage;
      if (enemy.Healt < 0)
      {
        enemy.Healt = 0;
      }
      Console.WriteLine($"{this.Name} hitted {enemy.Name}, target lost {damage} points of HP");
    }
  }
}