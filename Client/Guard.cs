namespace VisualStudioIntegreate.Client
{
    using System;

    public static class Guard
    {
        public static void IsNotNull<T>(T argument, string argumentName, string message) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }

        public static void IsNot<T>(T argument, Func<T, bool> vaidationExpression, string argumentName, string message)
        {
            if (!vaidationExpression(argument))
            {
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}