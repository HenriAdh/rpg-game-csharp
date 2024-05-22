using System;
namespace RPG
{
  public class Battle
  {
    public Character Hero;
    public Character Enemy;
    public int Round = 1;

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

    public void InitBattle()
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
        Console.WriteLine($"");
        string? opt = Console.ReadLine();
        if (opt == "1")
        {
          Console.Clear();
          if (this.Hero.Speed >= this.Enemy.Speed)
          {
            Console.WriteLine("\nYour Turn!");
            int hero_luck = this.RollTheDiceAsync();
            this.Hero.Attack(this.Enemy, hero_luck);

            Console.ReadKey();

            Console.WriteLine("\nEnemy Turn!");
            int enemy_luck = this.RollTheDiceAsync();
            this.Enemy.Attack(this.Hero, enemy_luck);
          }
          else
          {
            Console.WriteLine("\nEnemy Turn!");
            int enemy_luck = this.RollTheDiceAsync();
            this.Enemy.Attack(this.Hero, enemy_luck);

            Console.ReadKey();

            Console.WriteLine("\nYour Turn!");
            int hero_luck = this.RollTheDiceAsync();
            this.Hero.Attack(this.Enemy, hero_luck);
          }
          if (Hero.Healt <= 0 || Enemy.Healt <= 0)
          {
            break;
          }
          this.Round++;
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
          Console.WriteLine("\nPlease, choose an valid option.");
        }
        Console.ReadKey();
      }
    }

    public int RollTheDiceAsync()
    {
      Random random = new Random();
      int randint = random.Next(0, 21) + 1;
      Console.Write("\nRolling the dice");
      Pause();
      Console.Write(".");
      Pause();
      Console.Write(".");
      Pause();
      Console.Write(".\n");
      Pause();
      Console.Write($"{randint}!!!\n");
      return randint;
    }

    private void Pause()
    {
      Thread.Sleep(300);
    }
  }
}