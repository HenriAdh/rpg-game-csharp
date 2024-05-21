using System;
namespace RPG
{
  public class Battle
  {
    public Character Hero;
    public Character Enemy;
    public int Round = 0;

    public Battle(Character hero, Character enemy)
    {
      this.Hero = hero;
      this.Enemy = enemy;
    }

    public void ShowStatsBattle()
    {
      Console.WriteLine($"Round: {this.Round}");
      Console.WriteLine($"{this.Hero.Name} healt: {this.Hero.Healt}");
      Console.WriteLine($"{this.Enemy.Name} healt: {this.Enemy.Healt}");
      Console.WriteLine("");
    }

    public async void InitBattle()
    {
      while (true)
      {
        Console.Clear();
        this.ShowStatsBattle();
        Console.WriteLine($"What would you like to do?");
        Console.WriteLine($"[1] Attack {this.Enemy.Name}");
        Console.WriteLine($"[2] ShowBag");
        Console.WriteLine($"[3] Show Your Stats");
        Console.WriteLine($"[4] Show Enemy Stats");
        string? opt = Console.ReadLine();
        if (opt == "1")
        {
          if (this.Hero.Speed > this.Enemy.Speed)
          {
            int hero_luck = await this.RollTheDiceAsync();
            Console.WriteLine("\nYour Turn!");
            this.Hero.Attack(this.Enemy, hero_luck);
            Console.ReadKey();
            Console.WriteLine("\nEnemy Turn!");
            int enemy_luck = await this.RollTheDiceAsync();
            this.Enemy.Attack(this.Hero, enemy_luck);
            Console.ReadKey();
          }

        }
        else if (opt == "2")
        {
          this.Hero.ShowBag();
        }
        else if (opt == "3")
        {
          this.Hero.Show();
        }
        else if (opt == "4")
        {
          this.Enemy.Show();
        }
        else
        {
          Console.WriteLine("\nChoose a valid option!");
        }
      }
    }

    public async Task<int> RollTheDiceAsync()
    {
      Random random = new();
      int randint = random.Next(0, 21) + 1;
      Console.WriteLine("\nRolling the dice");
      await Pause();
      Console.Write(".");
      Console.Write(".");
      Console.Write(".");
      Console.WriteLine($"{randint}!!!");
      return randint;
    }

    async Task Pause()
    {
      await Task.Delay(1000);
    }
  }
}