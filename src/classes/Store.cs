
namespace RPG
{
  class Store
  {
    public Item[] ListItem = new Item[10];
    private Weapons Weapons = new Weapons();
    private Armors Armors = new Armors();
    private Item[] ItemsToBuy = new Item[10];
    public Store(Character hero)
    {
      this.ItemsToBuy = this.DrawItems(hero);
    }

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
      Console.Clear();
      Console.WriteLine($"Coins: ${hero.Coins}");
      Console.WriteLine($"--------------");
      int x;
      for (x = 0; x < this.ItemsToBuy.Length; x++)
      {
        int value = 0;
        value = this.ItemsToBuy[x].Rarity switch
        {
          "Common" => 20,
          "Rare" => 40,
          "Epic" => 80,
          "Mythic" => 160,
          "Legendary" => 320,
          _ => 0
        };
        Console.WriteLine($"[{x + 1}] {this.ItemsToBuy[x].Rarity}: {this.ItemsToBuy[x].Name} - ${value}");
      }
      Console.WriteLine($"[{x + 1}] Exit");
      Console.WriteLine($"");

      string? opt = Console.ReadLine();
      if (opt != null && opt.ToString() == $"{x + 1}")
      {
        return;
      }
      else if (opt != null && opt != "")
      {
        int optInt = new Functions().TryConvertToInt(opt);
        if (optInt != 0)
        {
          optInt--;
          int value = this.ItemsToBuy[optInt].Rarity switch
          {
            "Common" => 20,
            "Rare" => 40,
            "Epic" => 80,
            "Mythic" => 160,
            "Legendary" => 320,
            _ => 0
          };

          if (hero.Coins < value)
          {
            Console.WriteLine("\nInsuficient coins!");
            Console.ReadKey();
            return;
          }
          else
          {
            hero.AddItemToBag(this.ItemsToBuy[optInt]);
            hero.Coins -= value;
            Console.WriteLine($"{ItemsToBuy[optInt].Name} pushased by {value} Coins!");
            Console.ReadKey();
            return;
          }
        }
      }
      Console.ReadKey();
    }

    private void SellItems(Character hero)
    {
      Console.Clear();
      Console.WriteLine($"Coins: ${hero.Coins}");
      Console.WriteLine($"--------------");
      int x = 0;
      int value = 0;
      for (x = 0; x < hero.Bag.Length; x++)
      {
        if (hero.Bag[x] == null) break;
        value = GetValue(hero.Bag[x]);

        Console.WriteLine($"[{x + 1}] {hero.Bag[x].Rarity}: {hero.Bag[x].Name} - ${value}");
      }
      Console.WriteLine($"[{x + 1}] Exit");
      Console.WriteLine($"");

      string? opt = Console.ReadLine();
      if (opt != null && opt.ToString() == $"{x + 1}")
      {
        return;
      }
      else if (opt != null && opt != "")
      {
        int optInt = new Functions().TryConvertToInt(opt);
        if (optInt != 0)
        {
          optInt--;
          value = GetValue(hero.Bag[optInt]);
          hero.Coins += value;
          Console.WriteLine($"{hero.Bag[optInt].Name} selled by {value} Coins!");
          hero.Bag[optInt].Amount--;
          if (hero.Bag[optInt].Amount <= 0)
          {
            if (hero.ArmorEquiped == hero.Bag[optInt]) hero.ArmorEquiped = null;
            if (hero.WeaponEquiped == hero.Bag[optInt]) hero.WeaponEquiped = null;

            List<Item?> list = [.. hero.Bag];
            list.RemoveAt(optInt);
            list.Add(null);
            hero.Bag = [.. list];
          }


          Console.ReadKey();
          return;
        }
      }
      Console.ReadKey();
    }

    public Item[] DrawItems(Character hero)
    {
      Item?[] classWeapons = new Item[2];
      Item[] randomWeapons = new Item[3];
      Item[] randomArmors = new Item[3];

      for (int x = 0; x < 2; x++)
      {
        classWeapons[x] = Weapons.RandomWeaponByType(hero.WeaponType);
      }
      for (int x = 0; x < 3; x++)
      {
        randomWeapons[x] = Weapons.RandomWeapon();
        randomArmors[x] = Armors.RandomArmor();
      }

      Heal heal_potion = new("Small Heal Potion", 10, 5, "Common", 1);

      return [.. classWeapons, .. randomWeapons, .. randomArmors, heal_potion];
    }

    private int GetValue(Item item)
    {
      int value;
      value = item.Rarity switch
      {
        "Common" => 20,
        "Rare" => 40,
        "Epic" => 80,
        "Mythic" => 160,
        "Legendary" => 320,
        _ => 0
      };

      value /= 3;
      value += value / 10 * item.Level;
      if (value <= 0) value = 1;

      return value;
    }
  }
}