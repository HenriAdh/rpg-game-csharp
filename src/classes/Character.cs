using System.Collections;
using System.Data.Common;

namespace RPG
{
  public class Character
  {
    public string Name;
    public int Healt;
    public int BaseHealt;
    public int Damage;
    public int BaseDamage;
    public int Speed;
    public int BaseSpeed;
    public Item[] Bag = new Item[10];
    public Item? WeaponEquiped;
    public Item? ArmorEquiped;
    public int Experience = 0;
    public int ExperienceToNextLevel = 10;
    public int Level = 1;
    public int Coins = 10;
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
      int defense = 0;
      if (this.ArmorEquiped != null)
      {
        defense += this.ArmorEquiped.Power;
      }

      Console.Clear();
      Console.WriteLine($"LEVEL: {this.Level} - {this.Experience}/{this.ExperienceToNextLevel}");
      Console.WriteLine($"NAME: {this.Name}");
      Console.WriteLine($"HP: {this.Healt}");
      Console.WriteLine($"DAMAGE: {damage}");
      Console.WriteLine($"SPEED: {this.Speed}");
      Console.WriteLine($"DEFENSE: {defense}");
      Console.WriteLine($"WEAPON: {this.WeaponEquiped?.Name ?? "Nothing"}");
      Console.WriteLine($"ARMOR: {this.ArmorEquiped?.Name ?? "Nothing"}");

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
            if (this.Bag[index].GetType() == Type.GetType("RPG.Weapon"))
            {
              this.EquipWeapon(this.Bag[index]);
            }
            else if (this.Bag[index].GetType() == Type.GetType("RPG.Armor"))
            {
              this.EquipArmor(this.Bag[index]);
            }
            else
            {
              Console.WriteLine("Nothing...");
            }
          }
          else if (option == "2")
          {
            var list = this.Bag.ToList();
            list.RemoveAt(index);
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            list.Add(null);
            this.Bag = [.. list];
          }
          break;
        }
        Console.WriteLine($"\nPlease, choose an valid option.\n");
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
          Console.WriteLine("The bag is full!");
          return;
        }
      }
    }

    public void EquipWeapon(Item weapon)
    {
      this.WeaponEquiped = weapon;
      Console.WriteLine($"{this.Name} equipped a weapon {weapon.Name}.");
    }

    public void EquipArmor(Item armor)
    {
      this.ArmorEquiped = armor;
      Console.WriteLine($"{this.Name} equipped an armor {armor.Name}.");
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
        damage += this.WeaponEquiped.Power;
      }
      if (luck < 6)
      {
        damage /= 2;
      }
      if (luck > 15)
      {
        damage *= 2;
      }
      if (enemy.ArmorEquiped != null)
      {
        damage -= enemy.ArmorEquiped.Power;
      }
      enemy.Healt -= damage;
      if (enemy.Healt < 0)
      {
        enemy.Healt = 0;
      }
      Console.WriteLine($"{this.Name} hitted {enemy.Name}, dealt {damage} points of damage.");
    }

    public void LevelUp()
    {
      this.Level += 1;

      this.Experience -= this.ExperienceToNextLevel;
      this.ExperienceToNextLevel += this.Level * 2;

      this.BaseHealt += this.BaseHealt / 10;
      this.Healt = this.BaseHealt;

      this.BaseDamage += this.BaseDamage / 10;
      this.Damage = this.BaseDamage;

      this.BaseSpeed += this.BaseSpeed / 10;
      this.Speed = this.BaseSpeed;

      Console.WriteLine($"Congratulations, {this.Name} up to level {this.Level}!");
      Console.WriteLine($"Base healt increased to {this.BaseHealt}!");
      Console.WriteLine($"Base damage increased to {this.BaseDamage}!");
      Console.WriteLine($"Base speed increased to {this.BaseSpeed}!");
      Console.ReadKey();
    }
  }
}