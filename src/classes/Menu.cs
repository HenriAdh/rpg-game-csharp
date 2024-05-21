// namespace RPG
// {
//   public class Menu
//   {
//     public Menu() { }

//     public void ShowMenu()
//     {
//       Console.Clear();
//       Console.WriteLine($"What would you like to do?");
//       Console.WriteLine($"--------------------------");
//       Console.WriteLine($"[1] Attack");
//       Console.WriteLine($"[2] Show Stats");
//       Console.WriteLine($"[3] Show bag");
//       Console.WriteLine($"[5] Exit");
//       Console.WriteLine($"--------------------------");
//     }

//     public void DoAction(string action, Character hero, Character enemy)
//     {
//       switch (action)
//       {
//         case "1":
//           Battle battle = new Battle(hero, enemy);
//           battle.InitBattle();
//           break;
//         case "2":
//           hero.Show();
//           break;
//         case "3":
//           hero.ShowBag();
//           break;
//         default:
//           Console.WriteLine("Choose a valid option!");
//           break;
//       }
//     }
//   }
// }