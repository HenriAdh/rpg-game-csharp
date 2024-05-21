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
    public Item[] Bag = new Item[10];
    public Item? WeaponEquiped;

    public Character(string name)
    {
      Name = name;
    }

    public void Show()
    {
      int damage = this.Damage;
      if (this.WeaponEquiped != null)
      {
        damage += this.WeaponEquiped.Power;
      }
      Console.WriteLine();
      Console.WriteLine($"NAME: {this.Name}");
      Console.WriteLine($"HP: {this.Healt}");
      Console.WriteLine($"DAMAGE: {damage}");
      Console.WriteLine($"SPEED: {this.Speed}");
      int count = 0;
      for (int x = 0; x < this.Bag.Length; x++)
      {
        if (this.Bag[x] == null)
        {
          break;
        }
        count++;
      }
      Console.WriteLine($"BAG: {count}/{this.Bag.Length}");
    }

    public void ShowBag()
    {
      string itens = "";
      int x;

      for (x = 0; x < this.Bag.Length; x++)
      {
        if (this.Bag[x] == null)
        {
          break;
        }
        itens += $"\t[{x + 1}] " + this.Bag[x].Name;
      }
      while (true)
      {
        Console.Clear();
        Console.WriteLine($"Itens in the bag: \n{itens}");
        Console.WriteLine($"\t[{x + 1}] Back");
        string? opt = Console.ReadLine();
        if (opt == Convert.ToString(x + 1))
        {
          break;
        }
        int index = Convert.ToInt32(opt) - 1;
        if (this.Bag[index] != null)
        {
          this.Bag[index].ShowItem();
          Console.WriteLine($"\n[1] Use");
          Console.WriteLine($"[2] Drop");
          Console.WriteLine($"[3] Back");
          Console.WriteLine("");
          string? option = Console.ReadLine();
          if (option == "1")
          {
            this.EquipWeapon(this.Bag[index]);
          }
          else if (option == "2")
          {
            var list = this.Bag.ToList();
            list.RemoveAt(index);
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            list.Add(null);
            this.Bag = [.. list];
            Console.WriteLine($"\n\nnovo tamanho: {this.Bag.Length}");
          }
          break;
        }
        Console.WriteLine($"\nPlease, choose a valid option!\n");
        Console.ReadKey();
      }
    }

    public void AddItemToBag(Item new_item)
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

    public void EquipWeapon(Item weapon)
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

    public void Attack(Character enemy, int luck = 10)
    {
      int damage = this.Damage;
      if (!(this.WeaponEquiped == null))
      {
        damage = this.WeaponEquiped.Power;
      }
      if (luck < 6)
      {
        damage /= 2;
      }
      if (luck > 15)
      {
        damage *= 2;
      }
      enemy.Healt -= damage;
      if (enemy.Healt < 0)
      {
        enemy.Healt = 0;
      }
      Console.WriteLine($"{this.Name} hitted {enemy.Name}, dealt {damage} points of damage");
    }
  }
}