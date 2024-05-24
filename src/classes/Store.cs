
namespace RPG
{
  class Store
  {
    public Item[] ListItem = new Item[10];
    private Weapons Weapons = new Weapons();
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
        Console.WriteLine($"[{x + 1}] {this.ItemsToBuy[x].Name} - {this.ItemsToBuy[x].Rarity} - ${value}");
      }
      Console.WriteLine($"[{x + 1}] Exit");
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