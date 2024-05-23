namespace RPG
{
  public class Names
  {
    public string[] ListNames = [
      "Alexander", "Isabella", "William", "Sophia", "Thomas", "Amelia", "James",
      "Charlotte", "Edward", "Elizabeth", "Aeliana", "Elrohir", "Luthien",
      "Thandor", "Faelwen", "Thalion", "Arannis", "Lirael", "Elerosse",
      "Galadriel", "Grommash", "Throg", "Grishnak", "Morgash", "Brak", "Ulgor",
      "Krug", "Zargash", "Durog", "Muglash", "Thorin", "Durin", "Bofur",
      "Dwalin", "Gimli", "Balin", "Kili", "Fili", "Borin", "Dis", "Snaggle",
      "Ruk", "Gribble", "Zog", "Muck", "Skrit", "Gurt", "Splinter", "Crag",
      "Blight", "Aiden", "Elysia", "Draven", "Freya", "Kael", "Lyra", "Zane",
      "Mira", "Thorne", "Aria", "Liora", "Seraphina", "Yara", "Eira", "Astrid",
      "Talia", "Elara", "Rhea", "Nyx", "Cora", "Alaric", "Fenrir", "Rowan",
      "Cedric", "Lucian", "Orion", "Theron", "Varian", "Magnus", "Zephyr"
    ];

    public Names() { }

    public string RandName()
    {
      Random random = new Random();
      int rdNumber = random.Next(0, this.ListNames.Length);
      return this.ListNames[rdNumber];
    }
  }
}