namespace Utils
{
    public static class Utilities
    {
        public static bool IsZeroOrNegative(int value)
        {
            // Simple method
            return value <= 0;

            // Explicit method
            //bool result;

            //if (value <= 0) 
            //{
            //    result = true;
            //}
            //else
            //{
            //    result = false;
            //}

            //return result;

            // Simple explict using ternary
            //return value <= 0 ? true : false;
        }

        public static bool IsPositive(int value) => value > 0 ? true : false;
        public static bool IsPositive(double value) => value > 0.0;
        public static bool IsPositive(decimal value) => value > 0.0M;

        // Expression-bodied method
        public static bool IsNullEmptyOrWhiteSpace(string value) => 
            String.IsNullOrWhiteSpace(value);

        public static bool IsInTheFuture(DateOnly value) => value > DateOnly.FromDateTime(DateTime.Now);
    }
}