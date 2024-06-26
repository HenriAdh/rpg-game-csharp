namespace RPG
{
  public class Weapons
  {
    public Weapon[] Sword = [
      new Sword("Steelblade", 10, "Common"),
      new Sword("Moonlit Edge", 15, "Rare"),
      new Sword("Stormbringer", 20, "Epic"),
      new Sword("Soulreaver", 25, "Mythic"),
      new Sword("Eternal Flame", 30, "Legendary"),
    ];
    public Weapon[] Arch = [
      new Arch("Willow Bow", 13, "Common"),
      new Arch("Starlight Bow", 18, "Rare"),
      new Arch("Eagle's Cry", 23, "Epic"),
      new Arch("Dragon's Breath", 28, "Mythic"),
      new Arch("Ethereal Longbow", 33, "Legendary"),
    ];
    public Weapon[] Axe = [
      new Axe("Iron Cleaver", 13, "Common"),
      new Axe("Thunderstrike", 18, "Rare"),
      new Axe("Bloodfury", 23, "Epic"),
      new Axe("Earthshaker", 28, "Mythic"),
      new Axe("Ragnarok's Wrath", 33, "Legendary"),
    ];
    public Weapon[] Dagger = [
      new Dagger("Shadowtip", 15, "Common"),
      new Dagger("Nightshade", 20, "Rare"),
      new Dagger("Venomstrike", 25, "Epic"),
      new Dagger("Silencer", 30, "Mythic"),
      new Dagger("Death's Whisper", 35, "Legendary"),
    ];
    public Weapon[] Stave = [
      new Stave("Oakwood Staff", 10, "Common"),
      new Stave("Moonbeam Rod", 15, "Rare"),
      new Stave("Stormcaller's Wand", 20, "Epic"),
      new Stave("Elderwood Scepter", 25, "Mythic"),
      new Stave("Arcane Conduit", 30, "Legendary"),
    ];

    public Weapon[] Instrument = [
      new Instrument("Traveler's Lute", 10, "Common"),
      new Instrument("Silverstring Harp", 15, "Rare"),
      new Instrument("Melodymaker Lyre", 20, "Epic"),
      new Instrument("Harmony's Echo", 25, "Mythic"),
      new Instrument("Celestial Symphony", 30, "Legendary"),
    ];

    public Weapon? RandomWeaponByType(string type)
    {
      type = type.ToUpper();
      Dictionary<string, Weapon[]> lists = new Dictionary<string, Weapon[]>
      {
        { "SWORD", this.Sword },
        { "ARCH", this.Arch },
        { "AXE", this.Axe },
        { "STAVE", this.Stave },
        { "DAGGER", this.Dagger },
        { "INSTRUMENT", this.Instrument },
      };

      if (lists[type] != null)
      {
        Random random = new Random();
        int rdNumber = random.Next(0, 100) + 1;
        int i = GetPercent(rdNumber);
        return lists[type][i];
      }
      else
      {
        return null;
      }
    }

    public Weapon RandomWeapon()
    {
      Weapon[][] items = [this.Sword, this.Arch, this.Axe, this.Stave, this.Dagger, this.Instrument];
      Random random = new Random();
      int x = random.Next(0, items.Length);
      int y = random.Next(0, 100) + 1;

      int z = GetPercent(y);

      return items[x][z];
    }

    private static int GetPercent(int number)
    {
      int rarity;
      if (number <= 60) rarity = 1;
      else if (number <= 85) rarity = 2;
      else if (number <= 95) rarity = 3;
      else if (number <= 99) rarity = 4;
      else rarity = 5;

      return rarity - 1;
    }
  }
}