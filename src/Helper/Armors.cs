namespace RPG
{
  public class Armors
  {
    public Item[] Armor = [
      new Sword("Ironplate Armor", 10, "Common"),
      new Sword("Leather Tunic", 10, "Common"),
      new Sword("Chainmail Vest", 10, "Common"),
      new Sword("Silverguard Armor", 15, "Rare"),
      new Sword("Elvenhide Jerkin", 15, "Rare"),
      new Sword("Bronzeplate Breastplate", 15, "Rare"),
      new Sword("Dragonscale Mail", 20, "Epic"),
      new Sword("Mystic Guardian Armor", 20, "Epic"),
      new Sword("Celestial Aegis", 25, "Mythic"),
      new Sword("Phantom's Embrace", 25, "Mythic"),
      new Sword("Eternal Vanguard", 30, "Legendary"),
    ];

    public Item RandomArmor()
    {
      Random random = new Random();
      int x = random.Next(0, 100) + 1;
      int y = GetPercent(x);

      return this.Armor[y];
    }

    private static int GetPercent(int number)
    {
      int rarity;

      if (number <= 20) rarity = 1;
      else if (number <= 40) rarity = 2;
      else if (number <= 60) rarity = 3;

      else if (number <= 69) rarity = 4;
      else if (number <= 77) rarity = 5;
      else if (number <= 85) rarity = 6;

      else if (number <= 90) rarity = 7;
      else if (number <= 95) rarity = 8;

      else if (number <= 97) rarity = 9;
      else if (number <= 99) rarity = 10;

      else rarity = 11;

      return rarity - 1;
    }
  }
}