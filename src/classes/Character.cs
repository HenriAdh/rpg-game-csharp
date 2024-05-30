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
    public int Mana;
    public int BaseMana;
    public Item[] Bag = new Item[10];
    public Weapon? WeaponEquiped;
    public Item? ArmorEquiped;
    public int Experience = 0;
    public int ExperienceToNextLevel = 10;
    public int Level = 0;
    public int Coins = 10;
    private int Luck = 10;
    public Skills? ArsenalSkills;
    public int DamageBuff = 0;
    public int TimerDamageBuff = 0;
    public int DamageDebuff = 0;
    public int TimerDamageDebuff = 0;
    public int ArmorBuff = 0;
    public int TimerArmorBuff = 0;
    public int ArmorDebuff = 0;
    public int TimerArmorDebuff = 0;
    public int LuckBuff = 0;
    public int TimerLuckBuff = 0;
    public int LuckDebuff = 0;
    public int TimerLuckDebuff = 0;
    public int SpeedBuff = 0;
    public int TimerSpeedBuff = 0;
    public int SpeedDebuff = 0;
    public int TimerSpeedDebuff = 0;
    public string WeaponType = "";
    public Character(string name)
    {
      Name = name;
      Armors armors = new Armors();
      Item armor = armors.RandomArmor();
      this.AddItemToBag(armor);
      this.ArmorEquiped = armor;
      Item heal_potion = new Heal("Small Heal Potion", 20, 2, "Common", 1);
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
      Console.WriteLine($"COINS:   {this.Coins}");

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
          return;
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
            while (true)
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
                break;
              }
              else if (option == "2")
              {
                List<Item?> list = [.. this.Bag];
                list.RemoveAt(index);
                list.Add(null);
                this.Bag = [.. list];
                break;
              }
              else
              {
                Console.WriteLine($"\nPlease, choose an valid option.\n");
                Console.ReadKey();
              }
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

    public void EquipWeapon(Weapon weapon)
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

    public virtual void Attack(Character enemy, string option = "1")
    {
      int damage = this.Damage,
        enemy_armor = enemy.ArmorEquiped?.Power ?? 0,
        luck = this.Luck;

      // Console.WriteLine($"Damage Buff: {this.DamageBuff}");
      // Console.WriteLine($"Damage Buff Timer: {this.TimerDamageBuff}");
      // Console.WriteLine($"Damage Debuff: {this.DamageDebuff}");
      // Console.WriteLine($"Damage Debuff Timer: {this.TimerDamageDebuff}");

      // Console.WriteLine($"Armor Buff: {this.ArmorBuff}");
      // Console.WriteLine($"Armor Buff Timer: {this.TimerArmorBuff}");
      // Console.WriteLine($"Armor Debuff: {this.ArmorDebuff}");
      // Console.WriteLine($"Armor Debuff Timer: {this.TimerArmorDebuff}");

      // Console.WriteLine($"Luck Buff: {this.LuckBuff}");
      // Console.WriteLine($"Luck Buff Timer: {this.TimerLuckBuff}");
      // Console.WriteLine($"Luck Debuff: {this.LuckDebuff}");
      // Console.WriteLine($"Luck Debuff Timer: {this.TimerLuckDebuff}");

      this.RollTheDiceAsync();
      if (!(this.WeaponEquiped == null))
      {
        damage += this.WeaponEquiped.Power + this.WeaponEquiped.Level / 10 * this.WeaponEquiped.Level / 5;
      }

      if (this.DamageBuff > 0 && this.TimerDamageBuff > 0)
      {
        damage += this.DamageBuff;
        this.TimerDamageBuff--;
        if (this.TimerDamageBuff == 0) this.DamageBuff = 0;
      }
      if (this.DamageDebuff > 0 && this.TimerDamageDebuff > 0)
      {
        damage -= this.DamageDebuff;
        this.TimerDamageDebuff--;
        if (this.TimerDamageDebuff == 0) this.DamageDebuff = 0;
      }
      if (damage < 0) damage = 0;

      if (this.LuckBuff > 0 && this.TimerLuckBuff > 0)
      {
        luck += this.LuckBuff;
        this.TimerLuckBuff--;
        if (this.TimerLuckBuff == 0) this.LuckBuff = 0;
      }
      if (this.LuckDebuff > 0 && this.TimerLuckDebuff > 0)
      {
        luck -= this.LuckDebuff;
        this.TimerLuckDebuff--;
        if (this.TimerLuckDebuff == 0) this.LuckDebuff = 0;
      }
      if (luck < 1) luck = 1;
      else if (luck > 20) luck = 20;

      if (luck < 6) damage /= 2;
      if (luck > 14) damage *= 2;

      if (enemy.ArmorBuff > 0 && enemy.TimerArmorBuff > 0)
      {
        enemy_armor += enemy.ArmorBuff;
        enemy.TimerArmorBuff--;
        if (this.TimerArmorBuff == 0) this.ArmorBuff = 0;
      }
      if (enemy.ArmorDebuff > 0 && enemy.TimerArmorDebuff > 0)
      {
        enemy_armor -= enemy.ArmorDebuff;
        enemy.TimerArmorDebuff--;
        if (this.TimerArmorDebuff == 0) this.ArmorDebuff = 0;
      }
      if (enemy_armor < 0) enemy_armor = 0;

      damage -= enemy_armor;

      if (damage < 0) damage = 0;

      enemy.Healt -= damage;
      if (enemy.Healt < 0) enemy.Healt = 0;

      this.Mana += 2;
      if (this.Mana > this.BaseMana) this.Mana = this.BaseMana;

      Console.WriteLine($"{this.Name} hitted {enemy.Name}, dealt {damage} points of damage.");
      Console.ReadKey();
    }

    public void LevelUp()
    {
      this.Level += 1;

      this.Experience -= this.ExperienceToNextLevel;
      this.ExperienceToNextLevel += this.ExperienceToNextLevel / 5 + this.Level * 2;

      this.BaseHealt += this.BaseHealt / 20;
      this.Healt = this.BaseHealt;

      this.BaseDamage += this.BaseDamage / 12;
      this.Damage = this.BaseDamage;

      this.BaseSpeed += this.BaseSpeed / 5;
      this.Speed = this.BaseSpeed;

      Console.WriteLine($"Congratulations, {this.Name} up to level {this.Level}!");
      Console.WriteLine($"Base healt increased to {this.BaseHealt}!");
      Console.WriteLine($"Base damage increased to {this.BaseDamage}!");
      Console.WriteLine($"Base speed increased to {this.BaseSpeed}!");
      Console.ReadKey();
    }
    public void RollTheDiceAsync()
    {
      Random random = new Random();
      int randint = random.Next(0, 20) + 1;
      Console.Write("\nRolling the dice");
      Pause();
      Console.Write(".");
      Pause();
      Console.Write(".");
      Pause();
      Console.Write(". ");
      Pause();
      Console.Write($"{randint}!!!\n");
      this.Luck = randint;
    }

    private void Pause()
    {
      Thread.Sleep(300);
    }
  }
}