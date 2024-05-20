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
    public string[] Bag = new string[10];
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
      int count = 0;
      for (int x = 0; x < 10; x++)
      {
        if (Bag[x] == null)
        {
          break;
        }
        count++;
      }
      Console.WriteLine($"BAG: {count}/{LimitBag}");
    }

    public void ShowBag()
    {
      string itens = "";
      for (int x = 0; x < Bag.Length; x++)
      {
        if (Bag[x] == null)
        {
          break;
        }
        if (x != 0)
        {
          itens += ", ";
        }
        itens += Bag[x];
      }
      Console.WriteLine($"Itens in the bag: {itens}");
    }

    public void AddItemToBag(string new_item)
    {
      for (int x = 0; x < 11; x++)
      {
        if (Bag[x] == null)
        {
          Bag[x] = new_item;
          return;
        }
        if (x == 10)
        {
          Console.WriteLine("Bag is full!");
          return;
        }
      }
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