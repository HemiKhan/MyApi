namespace App_CleanArchitecture.Helpers

{
    public static class StringExtensions
    {
        public static string RemoveFromEnd(this string str, string toRemove)
        {
            if (str.EndsWith(toRemove))
                return str.Substring(0, str.Length - toRemove.Length);
            else
                return str;
        }

        public static string? GetImageName(this string? str)
        {
            if (str == null) return null;
            return str.Split('-')[1];
        }
    }
}
