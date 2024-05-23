namespace RPG
{
  class Store
  {
    public Item[] ListItem = new Item[10];
    private Weapons Weapons = new Weapons();
    public Store() { }

    public void ShowStore(Character hero)
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine("  Store  ");
        Console.WriteLine("---------");
        Console.WriteLine("[1] Buy  ");
        Console.WriteLine("[2] Sell ");
        Console.WriteLine("[3] Exit \n");
        string? opt = Console.ReadLine();
        if (opt == "1")
        {
          this.BuyItems(hero);
        }
        else if (opt == "2")
        {
          this.SellItems(hero);
        }
        else if (opt == "3")
        {
          break;
        }
        else
        {
          Console.WriteLine($"\nPlease, choose an valid option.\n");
          Console.ReadKey();
        }
      }
    }

    private void BuyItems(Character hero)
    {
      Item[] itemsToBuy = this.DrawItems(hero);
      Console.Clear();
      for (int x = 0; x < itemsToBuy.Length; x++)
      {
        int value;
        value = itemsToBuy[x].Rarity switch
        {
          "Common" => 20,
          "Rare" => 40,
          "Epic" => 80,
          "Mythic" => 160,
          "Legendary" => 320,
          _ => 0
        };
        Console.WriteLine($"[{x + 1}] {itemsToBuy[x].Name} - {itemsToBuy[x].Rarity} - ${value}");
      }
      Console.ReadKey();
    }

    private void SellItems(Character hero)
    {
      Console.Clear();
      Console.WriteLine("Comming soon.");
      Console.ReadKey();
    }

    public Item[] DrawItems(Character hero)
    {
      Item?[] classWeapons = new Item[2];
      Item[] randomWeapons = new Item[3];
      for (int x = 0; x < 2; x++)
      {
        classWeapons[x] = Weapons.RandomWeaponByType(hero.WeaponType);
      }
      for (int x = 0; x < 3; x++)
      {
        randomWeapons[x] = Weapons.RandomWeapon();
      }

      return [.. classWeapons, .. randomWeapons];
    }
  }
}