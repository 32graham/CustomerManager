namespace CustomerManager.Utils
{
    public static class ErrorMessages
    {
        public static string PropertyIsRequired(string propertyName)
        {
            return string.Format("{0} is required", propertyName);
        }

        public static string PropertyMustBeBetween(
            string propertyName,
            string lowerBound,
            string upperBound)
        {
            return string.Format(
                "{0} must be between {1} and {2}",
                propertyName,
                lowerBound,
                upperBound);
        }
    }
}
