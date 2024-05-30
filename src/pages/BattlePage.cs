using System;
using System.Reflection.Metadata.Ecma335;
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
        Console.WriteLine($"--------------------------");
        Console.WriteLine($"[1] Battle {this.Enemy.Name}");
        Console.WriteLine($"[2] ShowBag");
        Console.WriteLine($"[3] Show Your Stats");
        Console.WriteLine($"[4] Show Enemy Stats");
        Console.WriteLine($"");
        string? opt = Console.ReadLine();
        if (opt == "1")
        {
          string opt_skill = this.WichSkill();
          string enemySkill = this.WichEnemySkill();
          Console.Clear();
          if (opt_skill != "3")
          {
            if (this.Hero.Speed + this.Hero.WeaponEquiped?.Range >= this.Enemy.Speed + this.Enemy.WeaponEquiped?.Range)
            {
              Console.WriteLine("\nYour Turn!");
              this.Hero.Attack(this.Enemy, opt_skill);

              if (Hero.Healt <= 0 || Enemy.Healt <= 0)
              {
                Console.WriteLine("");
                break;
              }

              Console.WriteLine("\nEnemy Turn!");
              this.Enemy.Attack(this.Hero, enemySkill);
            }
            else
            {
              Console.WriteLine("\nEnemy Turn!");
              this.Enemy.Attack(this.Hero, enemySkill);

              if (Hero.Healt <= 0 || Enemy.Healt <= 0)
              {
                Console.WriteLine("");
                break;
              }

              Console.WriteLine("\nYour Turn!");
              this.Hero.Attack(this.Enemy, opt_skill);
            }
            if (Hero.Healt <= 0 || Enemy.Healt <= 0)
            {
              Console.WriteLine("");
              break;
            }
            this.Round++;
          }
        }
        else if (opt == "2")
        {
          this.Hero.ShowBag();
          Console.ReadKey();
        }
        else if (opt == "3")
        {
          this.Hero.Show();
          Console.ReadKey();
        }
        else if (opt == "4")
        {
          this.Enemy.Show();
          Console.ReadKey();
        }
        else
        {
          Console.WriteLine("\nPlease, choose an valid option.");
          Console.ReadKey();
        }
      }
    }

    private string WichEnemySkill()
    {
      if (this.Enemy.Healt < this.Enemy.BaseHealt / 2 || this.Hero.Healt < this.Hero.BaseHealt || this.Enemy.Mana < (this.Enemy.ArsenalSkills?.SecondSkill.ManaCost ?? 0)) return "1";

      Random random = new();
      int random_number = random.Next(0, 5) + 1;
      if (random_number == 1) return "2";
      return "1";
    }

    private string WichSkill()
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine($"Mana: {this.Hero.Mana}/{this.Hero.BaseMana}");
        Console.WriteLine("Wich skill would do you use?");
        Console.WriteLine("[1] Simple Attack");
        if (this.Hero.ArsenalSkills != null)
        {
          Console.WriteLine($"[2] {this.Hero.ArsenalSkills.SecondSkill.Name} / mana cost: {this.Hero.ArsenalSkills.SecondSkill.ManaCost}");
        }
        Console.WriteLine("[3] Exit");
        Console.WriteLine("");

        string? opt = Console.ReadLine();
        if (opt == "2" && (this.Hero.ArsenalSkills?.SecondSkill.ManaCost ?? 0) > this.Hero.Mana)
        {
          Console.WriteLine("\nNot enough mana.");
          Console.ReadKey();
        }
        else
        {
          if (opt == "1" || opt == "2" || opt == "3")
          {
            return opt;
          }

          Console.WriteLine("\nPlease, choose an valid option.");
          Console.ReadKey();
        }
      }
    }

    public string CheckWinner(Character hero, Character enemy)
    {
      if (hero.Speed > enemy.Speed)
      {
        if (enemy.Healt <= 0) return "hero";
        return "enemy";
      }
      if (hero.Healt <= 0) return "enemy";
      return "hero";
    }
  }
}