namespace CustomerManager.Utils
{
    using System.Text.RegularExpressions;

    public static class CannedRegex
    {
        private static Regex emailAddress = new Regex(@".+@.+\..+", RegexOptions.Compiled);

        public static Regex EmailAddress
        {
            get
            {
                return emailAddress;
            }
        }
    }
}
