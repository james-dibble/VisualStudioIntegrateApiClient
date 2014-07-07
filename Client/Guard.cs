namespace VisualStudioIntegreate.Client
{
    using System;

    /// <summary>
    /// A class containing methods for validating arguments.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Check a value is not equal to null.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="argument">The value to validate.</param>
        /// <param name="argumentName">The arguments name.</param>
        /// <param name="message">
        /// The message to put into the <see cref="System.ArgumentNullException"/> if it does not pass.
        /// </param>
        public static void IsNotNull<T>(T argument, string argumentName, string message) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }

        /// <summary>
        /// Check a value passes a certain criterion.
        /// </summary>
        /// <typeparam name="T">The type of the value to check.</typeparam>
        /// <param name="argument">The value to check.</param>
        /// <param name="vaidationExpression">The criteria the value must meet.</param>
        /// <param name="argumentName">The arguments name.</param>
        /// <param name="message">
        /// The message to put into the <see cref="System.ArgumentException"/> if it does not pass.
        /// </param>
        public static void IsNot<T>(T argument, Func<T, bool> vaidationExpression, string argumentName, string message)
        {
            if (!vaidationExpression(argument))
            {
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}