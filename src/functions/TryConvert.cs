namespace RPG
{
  public class Functions
  {
    public int TryConvertToInt(string str)
    {
      try
      {
        int res = Convert.ToInt32(str);
        return res;
      }
      catch
      {
        return 0;
      }
    }
  }
}