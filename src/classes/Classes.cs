namespace RPG
{
  public class Knight : Character
  {
    public Knight(string name) : base(name)
    {
      Weapons weapons = new Weapons();
      base.BaseHealt = 100;
      base.Healt = 100;
      base.BaseDamage = 20;
      base.Damage = 20;
      base.BaseSpeed = 10;
      base.Speed = 10;
      base.WeaponType = "Sword";
      base.BaseMana = 10;
      base.Mana = 10;
      Weapon? weapon = weapons.RandomWeaponByType(base.WeaponType);
      if (weapon != null)
      {
        this.AddItemToBag(weapon);
        this.WeaponEquiped = weapon;
      }
      base.ArsenalSkills = new Skills("Intimidate", 5, 10);
    }

    public override void ShowClass()
    {
      Console.WriteLine(
        "The Knight is a stalwart defender and a master of melee combat. Clad\n" +
        "in heavy armor, they serve as the frontline warriors, protecting their\n" +
        "allies and overwhelming their foes with formidable strength and\n" +
        "unwavering courage. With a strong sense of duty and honor, Knights\n" +
        "are trained in various weapons, specializing in swords and shields.\n" +
        "Their resilience allows them to withstand great amounts of damage,\n" +
        "making them essential in any battle"
      );
    }

    public override void Attack(Character enemy, string option = "1")
    {
      if (option == "1")
      {
        base.Attack(enemy);
      }
      else
      {
        enemy.DamageDebuff += this.ArsenalSkills?.SecondSkill.Power ?? 0 + 1 * 8 / 10 * this.Level;
        enemy.TimerDamageDebuff += 2;
        this.Mana -= this.ArsenalSkills?.SecondSkill.ManaCost ?? 0;
        if (this.Mana < 0) this.Mana = 0;
        Console.WriteLine($"{this.Name} intimidate {enemy.Name}");
        Console.ReadKey();
      }
    }
  }

  public class Archer : Character
  {
    public Archer(string name) : base(name)
    {
      Weapons weapons = new Weapons();
      base.BaseHealt = 80;
      base.Healt = 80;
      base.BaseDamage = 25;
      base.Damage = 25;
      base.BaseSpeed = 15;
      base.Speed = 15;
      base.BaseMana = 10;
      base.Mana = 10;
      base.WeaponType = "Arch";
      Weapon? weapon = weapons.RandomWeaponByType(base.WeaponType);
      if (weapon != null)
      {
        this.AddItemToBag(weapon);
        this.WeaponEquiped = weapon;
      }
      base.ArsenalSkills = new Skills("Focus", 5, 5);
    }

    public override void ShowClass()
    {
      Console.WriteLine(
        "The Archer is a master of ranged combat, striking enemies from afar\n" +
        "with unparalleled precision and agility. Equipped with a bow and a\n" +
        "quiver of arrows, Archers excel at dealing damage while keeping a\n" +
        "safe distance from their foes. Their keen eyesight and swift reflexes\n" +
        "allow them to hit targets with deadly accuracy, making them invaluable\n" +
        "in both offensive and defensive roles. Whether in the dense forest or\n" +
        "open battlefield, Archers adapt to their surroundings, using stealth\n" +
        "and speed to their advantage"
      );
    }

    public override void Attack(Character enemy, string option = "1")
    {
      if (option == "1")
      {
        base.Attack(enemy);
      }
      else
      {
        this.LuckBuff += 5 + this.Level;
        this.TimerLuckBuff += 2;
        this.Mana -= this.ArsenalSkills?.SecondSkill.ManaCost ?? 0;
        if (this.Mana < 0) this.Mana = 0;
        Console.WriteLine($"{this.Name} is focused.");
        Console.ReadKey();
      }
    }
  }

  public class Mage : Character
  {
    public Mage(string name) : base(name)
    {
      Weapons weapons = new Weapons();
      base.BaseHealt = 70;
      base.Healt = 70;
      base.BaseDamage = 30;
      base.Damage = 30;
      base.BaseSpeed = 13;
      base.Speed = 13;
      base.BaseMana = 10;
      base.Mana = 10;
      base.WeaponType = "Stave";
      Weapon? weapon = weapons.RandomWeaponByType(base.WeaponType);
      if (weapon != null)
      {
        this.AddItemToBag(weapon);
        this.WeaponEquiped = weapon;
      }
      base.ArsenalSkills = new Skills("Charge", 5, 10);
    }

    public override void ShowClass()
    {
      Console.WriteLine(
        "The Mage is a wielder of arcane magic, capable of casting powerful\n" +
        "spells to devastate enemies and support allies. With a deep\n" +
        "understanding of the mystical arts, Mages harness elemental forces\n" +
        "to unleash devastating attacks from a distance. They possess a vast\n" +
        "repertoire of spells, ranging from offensive fireballs to protective\n" +
        "shields. Though physically frail, their magical prowess makes them\n" +
        "formidable opponents on the battlefield"
      );
    }

    public override void Attack(Character enemy, string option = "1")
    {
      if (option == "1")
      {
        base.Attack(enemy);
      }
      else
      {
        this.DamageBuff += 15 + 1 * 8 / 10 * this.Level;
        this.TimerDamageBuff += 1;
        this.Mana -= this.ArsenalSkills?.SecondSkill.ManaCost ?? 0;
        if (this.Mana < 0) this.Mana = 0;
        Console.WriteLine($"{this.Name} is charged.");
        Console.ReadKey();
      }
    }
  }

  public class Assassin : Character
  {
    public Assassin(string name) : base(name)
    {
      Weapons weapons = new Weapons();
      base.BaseHealt = 70;
      base.Healt = 70;
      base.BaseDamage = 25;
      base.Damage = 25;
      base.BaseSpeed = 20;
      base.Speed = 20;
      base.BaseMana = 10;
      base.Mana = 10;
      base.WeaponType = "Dagger";
      Weapon? weapon = weapons.RandomWeaponByType(base.WeaponType);
      if (weapon != null)
      {
        this.AddItemToBag(weapon);
        this.WeaponEquiped = weapon;
      }
      base.ArsenalSkills = new Skills("Fatal Blow", 10, 10);
    }

    public override void ShowClass()
    {
      Console.WriteLine(
        "The Assassin is a master of stealth and precision, specializing in\n" +
        "eliminating enemies with swift and deadly strikes. Trained in the\n" +
        "arts of infiltration and subterfuge, Assassins excel at dealing high\n" +
        "damage from the shadows and avoiding detection. Equipped with daggers,\n" +
        "poison, and other clandestine tools, they are deadly in close combat\n" +
        "and can swiftly dispatch their targets before vanishing without a trace"
      );
    }

    public override void Attack(Character enemy, string option = "1")
    {
      if (option == "1")
      {
        base.Attack(enemy);
      }
      else
      {
        this.DamageBuff += 10 + 1 * 8 / 10 * this.Level;
        this.TimerDamageBuff += 1;
        this.LuckBuff += 5;
        this.TimerLuckBuff += 1;
        this.Mana -= this.ArsenalSkills?.SecondSkill.ManaCost ?? 0;
        if (this.Mana < 0) this.Mana = 0;
        Console.WriteLine($"{this.Name} prepared a fatal blow.");
        Console.ReadKey();
      }
    }
  }

  public class Healer : Character
  {
    public Healer(string name) : base(name)
    {
      Weapons weapons = new Weapons();
      base.BaseHealt = 120;
      base.Healt = 120;
      base.BaseDamage = 15;
      base.Damage = 15;
      base.BaseSpeed = 10;
      base.Speed = 10;
      base.BaseMana = 10;
      base.Mana = 10;
      base.WeaponType = "Stave";
      Weapon? weapon = weapons.RandomWeaponByType(base.WeaponType);
      if (weapon != null)
      {
        this.AddItemToBag(weapon);
        this.WeaponEquiped = weapon;
      }
      base.ArsenalSkills = new Skills("Heal", 10, 30);
    }

    public override void ShowClass()
    {
      Console.WriteLine(
        "The Healer is a compassionate and vital member of any adventuring\n" +
        "party, specializing in restoring health and providing support to\n" +
        "their allies. Masters of restorative magic, Healers can mend wounds,\n" +
        "cure ailments, and bolster the defenses of their comrades. While not\n" +
        "primarily focused on offensive capabilities, their presence ensures\n" +
        "the survival and endurance of their team, making them indispensable\n" +
        "in prolonged battles"
      );
    }

    public override void Attack(Character enemy, string option = "1")
    {
      if (option == "1")
      {
        base.Attack(enemy);
      }
      else
      {
        int recovery_healt = 30 + 7 * 8 / 10 * this.Level;
        this.Healt += recovery_healt;
        this.Mana -= this.ArsenalSkills?.SecondSkill.ManaCost ?? 0;
        if (this.Mana < 0) this.Mana = 0;
        Console.WriteLine($"{this.Name} recovery {recovery_healt} healt points.");
        Console.ReadKey();
      }
    }
  }

  public class Paladin : Character
  {
    public Paladin(string name) : base(name)
    {
      Weapons weapons = new Weapons();
      base.BaseHealt = 150;
      base.Healt = 150;
      base.BaseDamage = 15;
      base.Damage = 15;
      base.BaseSpeed = 5;
      base.Speed = 5;
      base.BaseMana = 10;
      base.Mana = 10;
      base.WeaponType = "Sword";
      Weapon? weapon = weapons.RandomWeaponByType(base.WeaponType);
      if (weapon != null)
      {
        this.AddItemToBag(weapon);
        this.WeaponEquiped = weapon;
      }
      base.ArsenalSkills = new Skills("Divine defense", 5, 10);
    }

    public override void ShowClass()
    {
      Console.WriteLine(
        "The Paladin is a holy warrior, devoted to righteousness, justice,\n" +
        "and protecting the innocent. Clad in sturdy armor and wielding a\n" +
        "combination of martial prowess and divine magic, Paladins stand as\n" +
        "beacons of hope on the battlefield. They are sworn to uphold oaths\n" +
        "of virtue and purity, using their strength and conviction to smite\n" +
        "evil and defend the weak. With a balance of offense and defense,\n" +
        "Paladins are versatile champions capable of both dealing devastating\n" +
        "blows to their enemies and shielding their allies from harm"
      );
    }

    public override void Attack(Character enemy, string option = "1")
    {
      if (option == "1")
      {
        base.Attack(enemy);
      }
      else
      {
        this.ArmorBuff += 5 + 1 * 8 / 10 * this.Level;
        this.TimerArmorBuff += 3;
        this.Mana -= this.ArsenalSkills?.SecondSkill.ManaCost ?? 0;
        if (this.Mana < 0) this.Mana = 0;
        Console.WriteLine($"{this.Name} equip your self with the divine defense.");
        Console.ReadKey();
      }
    }
  }

  public class Barbarian : Character
  {
    public Barbarian(string name) : base(name)
    {
      Weapons weapons = new Weapons();
      base.BaseHealt = 80;
      base.Healt = 80;
      base.BaseDamage = 25;
      base.Damage = 25;
      base.BaseSpeed = 13;
      base.Speed = 13;
      base.BaseMana = 10;
      base.Mana = 10;
      base.WeaponType = "Axe";
      Weapon? weapon = weapons.RandomWeaponByType(base.WeaponType);
      if (weapon != null)
      {
        this.AddItemToBag(weapon);
        this.WeaponEquiped = weapon;
      }
      base.ArsenalSkills = new Skills("Berserker rage", 10, 10);
    }

    public override void ShowClass()
    {
      Console.WriteLine(
        "The Barbarian is a fierce and primal warrior, fueled by raw emotion\n" +
        "and untamed strength. Forged in the harsh wilderness, Barbarians\n" +
        "eschew armor and fancy weapons, preferring instead to rely on their\n" +
        "brute force and instinctual combat prowess. They rage into battle\n" +
        "with reckless abandon, shrugging off blows that would fell lesser\n" +
        "warriors and unleashing devastating attacks upon their enemies. With\n" +
        "their mighty shouts and unmatched ferocity, Barbarians strike fear\n" +
        "into the hearts of their foes and leave a trail of destruction in\n" +
        "their wake"
      );
    }

    public override void Attack(Character enemy, string option = "1")
    {
      if (option == "1")
      {
        base.Attack(enemy);
      }
      else
      {
        this.DamageBuff += 12 + 1 * 8 / 10 * this.Level;
        this.TimerDamageBuff += 3;

        this.ArmorDebuff += 4 + 7 * 8 / 10 * enemy.Level;
        this.TimerArmorDebuff += 3;
        this.Mana -= this.ArsenalSkills?.SecondSkill.ManaCost ?? 0;
        if (this.Mana < 0) this.Mana = 0;
        Console.WriteLine($"{this.Name} goes into berserker rage.");
        Console.ReadKey();
      }
    }
  }

  public class Bard : Character
  {
    public Bard(string name) : base(name)
    {
      Weapons weapons = new Weapons();
      base.BaseHealt = 80;
      base.Healt = 80;
      base.BaseDamage = 15;
      base.Damage = 15;
      base.BaseSpeed = 15;
      base.Speed = 15;
      base.BaseMana = 10;
      base.Mana = 10;
      base.WeaponType = "Instrument";
      Weapon? weapon = weapons.RandomWeaponByType(base.WeaponType);
      if (weapon != null)
      {
        this.AddItemToBag(weapon);
        this.WeaponEquiped = weapon;
      }
      base.ArsenalSkills = new Skills("Sing", 5, 10);
    }

    public override void ShowClass()
    {
      Console.WriteLine(
        "The Bard is a master of storytelling, music, and magic, captivating\n" +
        "audiences with their charisma and creativity. Armed with a repertoire\n" +
        "of spells, musical instruments, and a quick wit, Bards weave magic\n" +
        "into their performances, inspiring allies and confounding enemies\n" +
        "alike. They are versatile performers, equally adept at bolstering\n" +
        "their comrades with inspiring melodies as they are at disrupting\n" +
        "their foes with powerful enchantments. With their charm and cunning,\n" +
        "Bards navigate the world with grace and style, leaving a lasting\n" +
        "impression wherever they go"
      );
    }

    public override void Attack(Character enemy, string option = "1")
    {
      if (option == "1")
      {
        base.Attack(enemy);
      }
      else
      {
        this.DamageBuff += 5 + 7 * 8 / 10 * this.Level;
        this.TimerDamageBuff += 2;

        this.ArmorBuff += 5 + 7 * 8 / 10 * this.Level;
        this.TimerArmorBuff += 2;

        this.SpeedBuff += 5 + 7 * 8 / 10 * this.Level;
        this.TimerSpeedBuff += 2;

        this.LuckBuff += 3 + this.Level / 3;
        this.TimerLuckBuff += 2;
        enemy.TimerDamageDebuff += 2;
        this.Mana -= this.ArsenalSkills?.SecondSkill.ManaCost ?? 0;
        if (this.Mana < 0) this.Mana = 0;
        Console.WriteLine($"{this.Name} sings and buff your self.");
        Console.ReadKey();
      }
    }
  }
}