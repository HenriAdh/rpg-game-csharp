using System.Collections;
using System.Data.Common;

namespace RPG
{
  public abstract class Character
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
    public int Level = 0;
    public int Coins = 10;
    public string WeaponType = "";
    public Character(string name)
    {
      Name = name;
      Armors armors = new Armors();
      Item armor = armors.RandomArmor();
      this.AddItemToBag(armor);
      this.ArmorEquiped = armor;
      Item heal_potion = new Heal("Small Heal Potion", 10, 2, "Common", 1);
      this.AddItemToBag(heal_potion);
    }

    public virtual void ShowClass() { }

    private string ShowClassCharacter()
    {
      string character_class = this.GetType().ToString();
      string type = "";
      for (int x = 0; x < character_class.Length; x++)
      {
        if (x > 3) type += character_class[x];
      }
      return type;
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
      Console.WriteLine($"LEVEL:   {this.Level} - {this.Experience}/{this.ExperienceToNextLevel}");
      Console.WriteLine($"NAME:    {this.Name}");
      Console.WriteLine($"HP:      {this.Healt}");
      Console.WriteLine($"DAMAGE:  {damage}");
      Console.WriteLine($"SPEED:   {this.Speed}");
      Console.WriteLine($"DEFENSE: {defense}");
      Console.WriteLine($"WEAPON:  {this.WeaponEquiped?.Name ?? "Nothing"} - {this.WeaponEquiped?.Rarity ?? ""}");
      Console.WriteLine($"ARMOR:   {this.ArmorEquiped?.Name ?? "Nothing"} - {this.ArmorEquiped?.Rarity ?? ""}");
      Console.WriteLine($"CLASS:   {this.ShowClassCharacter()}");

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
      int x;
      while (true)
      {
        string itens = "";
        for (x = 0; x < this.Bag.Length; x++)
        {
          if (this.Bag[x] == null)
          {
            break;
          }
          itens += $"\n[{x + 1}] " + this.Bag[x].Name;
        }

        Console.Clear();
        Console.WriteLine($"Itens in the bag:");
        Console.WriteLine($"-----------------");
        Console.WriteLine($"{itens}");
        Console.WriteLine($"[{x + 1}] Back");
        Console.WriteLine("");
        string? opt = Console.ReadLine();
        if (opt == Convert.ToString(x + 1))
        {
          break;
        }
        if (opt == null || opt == "")
        {
          Console.WriteLine($"\nPlease, choose an valid option.\n");
          Console.ReadKey();
        }
        else
        {

          int index = Convert.ToInt32(opt) - 1;
          if (this.Bag[index] != null)
          {
            this.Bag[index].ShowItem();
            Console.WriteLine("");
            Console.WriteLine($"[1] Use");
            Console.WriteLine($"[2] Drop");
            Console.WriteLine($"[3] Back");
            Console.WriteLine("");
            string? option = Console.ReadLine();
            if (option == "1")
            {
              this.Bag[index].UseFunction(this);
              Console.ReadKey();
            }
            else if (option == "2")
            {
              List<Item?> list = [.. this.Bag];
              list.RemoveAt(index);
              list.Add(null);
              this.Bag = [.. list];
            }
            else
            {
              break;
            }
          }
          else
          {
            Console.WriteLine($"\nPlease, choose an valid option.\n");
            Console.ReadKey();
          }
        }
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

    public void RecoveryHealt(Item potion)
    {
      int previous_healt = this.Healt;
      this.Healt += potion.Power;
      if (this.Healt > this.BaseHealt)
      {
        this.Healt = this.BaseHealt;
      }
      Console.WriteLine($"{this.Name} drink {potion.Name} and recovery {this.Healt - previous_healt} points of healt.");
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
        damage += this.WeaponEquiped.Power + this.WeaponEquiped.Level / 10 * this.WeaponEquiped.Level / 5;
      }
      if (luck < 6)
      {
        damage /= 2;
      }
      if (luck > 14)
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
      this.ExperienceToNextLevel += this.ExperienceToNextLevel / 5 + this.Level * 2;

      this.BaseHealt += this.BaseHealt / 15;
      this.Healt = this.BaseHealt;

      this.BaseDamage += this.BaseDamage / 15;
      this.Damage = this.BaseDamage;

      this.BaseSpeed += this.BaseSpeed / 15;
      this.Speed = this.BaseSpeed;

      Console.WriteLine($"Congratulations, {this.Name} up to level {this.Level}!");
      Console.WriteLine($"Base healt increased to {this.BaseHealt}!");
      Console.WriteLine($"Base damage increased to {this.BaseDamage}!");
      Console.WriteLine($"Base speed increased to {this.BaseSpeed}!");
      Console.ReadKey();
    }
  }
}