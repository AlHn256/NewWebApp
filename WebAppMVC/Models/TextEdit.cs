namespace WebAppMVC.Models
{
    public static class StringExtension
    {
        public static string InMidleOf(this string Str, string Fr, string To)
        {
            if (Str.Length != 0 && Fr.Length != 0 && To.Length != 0)
            {

                if (Str.IndexOf(Fr) != -1)
                {
                    Str = Str.Substring(Str.IndexOf(Fr) + Fr.Length);

                    if (Str.IndexOf(To) != -1) Str = Str.Substring(0, Str.IndexOf(To));
                }
            }
            return Str;
        }
    }
    public class TextEdit
    {
    }
}
