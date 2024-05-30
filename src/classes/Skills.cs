namespace RPG
{
  public class Skill
  {
    public string Name;
    public int ManaCost;
    public int Power;

    public Skill(string name, int mana_cost, int power)
    {
      this.Name = name;
      this.ManaCost = mana_cost;
      this.Power = power;
    }
  }

  public class Skills
  {
    public Skill FirstSkill = new Skill("Attack", 0, 0);
    public Skill SecondSkill;

    public Skills(string name, int mana_cost, int power)
    {
      this.SecondSkill = new Skill(name, mana_cost, power);
    }
  }
}