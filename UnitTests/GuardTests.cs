namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VisualStudioIntegreate.Client;

    [TestClass]
    public class GuardTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIsNotNullWithNull()
        {
            Guard.IsNotNull<GuardTests>(null, string.Empty, string.Empty);
        }

        [TestMethod]
        public void TestIsNotNullWithValue()
        {
            Guard.IsNotNull<GuardTests>(this, string.Empty, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsNotWontBeReferenceObject()
        {
            Guard.IsNot<GuardTests>(null, test => test != null, string.Empty, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsNotWontBeValueObject()
        {
            Guard.IsNot(string.Empty, test => !string.IsNullOrEmpty(test), string.Empty, string.Empty);
        }

        [TestMethod]
        public void TestIsNotWillBeValueObject()
        {
            Guard.IsNot("Something", test => !string.IsNullOrEmpty(test), string.Empty, string.Empty);
        }
    }
}