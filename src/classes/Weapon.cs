namespace RPG
{
  public class Weapon
  {
    public string Name;
    public int Damage;
    public string Type;

    public Weapon(string name, int damage, string type)
    {
      this.Name = name;
      this.Damage = damage;
      this.Type = type;
    }
  }
}