namespace RPG
{
  public class Knight : Character
  {
    public Knight(string name) : base(name)
    {
      base.BaseHealt = 100;
      base.Healt = 100;
      base.BaseDamage = 20;
      base.Damage = 20;
      base.BaseSpeed = 10;
      base.Speed = 10;
      Item sword = new Sword("Rust Sword", 10, 1, "Commun");
      this.AddItemToBag(sword);
      Item armor = new Armor("Rust Armor", 5, "Commun", 1);
      this.AddItemToBag(armor);
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
  }

  public class Archer : Character
  {
    public Archer(string name) : base(name)
    {
      base.BaseHealt = 80;
      base.Healt = 80;
      base.BaseDamage = 25;
      base.Damage = 25;
      base.BaseSpeed = 15;
      base.Speed = 15;
      Item arch = new Arch("Small Bow", 13, 1, "Commun");
      this.AddItemToBag(arch);
      Item armor = new Armor("Leather Armor", 3, "Commun", 1);
      this.AddItemToBag(armor);
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
  }

  public class Mage : Character
  {
    public Mage(string name) : base(name)
    {
      base.BaseHealt = 70;
      base.Healt = 70;
      base.BaseDamage = 30;
      base.Damage = 30;
      base.BaseSpeed = 13;
      base.Speed = 13;
      Item stave = new Stave("Wood stave", 10, 1, "Commun");
      this.AddItemToBag(stave);
      Item armor = new Armor("Cloak", 3, "Commun", 1);
      this.AddItemToBag(armor);
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
  }

  public class Assassin : Character
  {
    public Assassin(string name) : base(name)
    {
      base.BaseHealt = 70;
      base.Healt = 70;
      base.BaseDamage = 25;
      base.Damage = 25;
      base.BaseSpeed = 20;
      base.Speed = 20;
      Item dagger = new Dagger("Rust Dagger", 15, 1, "Commun");
      this.AddItemToBag(dagger);
      Item armor = new Armor("Leather Armor", 2, "Commun", 1);
      this.AddItemToBag(armor);
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
  }

  public class Healer : Character
  {
    public Healer(string name) : base(name)
    {
      base.BaseHealt = 120;
      base.Healt = 120;
      base.BaseDamage = 15;
      base.Damage = 15;
      base.BaseSpeed = 10;
      base.Speed = 10;
      Item stave = new Stave("Wood stave", 10, 1, "Commun");
      this.AddItemToBag(stave);
      Item armor = new Armor("Cloak", 3, "Commun", 1);
      this.AddItemToBag(armor);
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
  }

  public class Paladin : Character
  {
    public Paladin(string name) : base(name)
    {
      base.BaseHealt = 150;
      base.Healt = 150;
      base.BaseDamage = 15;
      base.Damage = 15;
      base.BaseSpeed = 5;
      base.Speed = 5;
      Item sword = new Sword("Rust Sword", 10, 1, "Commun");
      this.AddItemToBag(sword);
      Item armor = new Armor("Rust Armor", 5, "Commun", 1);
      this.AddItemToBag(armor);
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
  }

  public class Barbarian : Character
  {
    public Barbarian(string name) : base(name)
    {
      base.BaseHealt = 80;
      base.Healt = 80;
      base.BaseDamage = 25;
      base.Damage = 25;
      base.BaseSpeed = 13;
      base.Speed = 13;
      Item axe = new Axe("Rust Axe", 10, 1, "Commun");
      this.AddItemToBag(axe);
      Item armor = new Armor("Leather Armor", 3, "Commun", 1);
      this.AddItemToBag(armor);
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
  }

  public class Bard : Character
  {
    public Bard(string name) : base(name)
    {
      base.BaseHealt = 80;
      base.Healt = 80;
      base.BaseDamage = 15;
      base.Damage = 15;
      base.BaseSpeed = 15;
      base.Speed = 15;
      Item mandolin = new Mandolin("Mandolin", 10, 1, "Commun");
      this.AddItemToBag(mandolin);
      Item armor = new Armor("Leather Armor", 5, "Commun", 1);
      this.AddItemToBag(armor);
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
  }
}