namespace RPG
{
  public class Weapons
  {
    public Item[] Sword = [
      new Sword("Steelblade", 10, "Common"),
      new Sword("Moonlit Edge", 15, "Rare"),
      new Sword("Stormbringer", 20, "Epic"),
      new Sword("Soulreaver", 25, "Mythic"),
      new Sword("Eternal Flame", 30, "Legendary"),
    ];
    public Item[] Arch = [
      new Arch("Willow Bow", 13, "Common"),
      new Arch("Starlight Bow", 18, "Rare"),
      new Arch("Eagle's Cry", 23, "Epic"),
      new Arch("Dragon's Breath", 28, "Mythic"),
      new Arch("Ethereal Longbow", 33, "Legendary"),
    ];
    public Item[] Axe = [
      new Axe("Iron Cleaver", 13, "Common"),
      new Axe("Thunderstrike", 18, "Rare"),
      new Axe("Bloodfury", 23, "Epic"),
      new Axe("Earthshaker", 28, "Mythic"),
      new Axe("Ragnarok's Wrath", 33, "Legendary"),
    ];
    public Item[] Dagger = [
      new Dagger("Shadowtip", 15, "Common"),
      new Dagger("Nightshade", 20, "Rare"),
      new Dagger("Venomstrike", 25, "Epic"),
      new Dagger("Silencer", 30, "Mythic"),
      new Dagger("Death's Whisper", 35, "Legendary"),
    ];
    public Item[] Stave = [
      new Stave("Oakwood Staff", 10, "Common"),
      new Stave("Moonbeam Rod", 15, "Rare"),
      new Stave("Stormcaller's Wand", 20, "Epic"),
      new Stave("Elderwood Scepter", 25, "Mythic"),
      new Stave("Arcane Conduit", 30, "Legendary"),
    ];

    public Item[] Instrument = [
      new Instrument("Traveler's Lute", 10, "Common"),
      new Instrument("Silverstring Harp", 15, "Rare"),
      new Instrument("Melodymaker Lyre", 20, "Epic"),
      new Instrument("Harmony's Echo", 25, "Mythic"),
      new Instrument("Celestial Symphony", 30, "Legendary"),
    ];

    public Item? RandomWeaponByType(string type)
    {
      type = type.ToUpper();
      Dictionary<string, Item[]> lists = new Dictionary<string, Item[]>
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
        int rdNumber = random.Next(0, lists[type].Length);
        return lists[type][rdNumber];
      }
      else
      {
        return null;
      }
    }

    public Item RandomWeapon()
    {
      Item[][] items = [this.Sword, this.Arch, this.Axe, this.Stave, this.Dagger, this.Instrument];
      Random random = new Random();
      int x = random.Next(0, items.Length);
      int y = random.Next(0, items[x].Length);

      return items[x][y];
    }
  }
}