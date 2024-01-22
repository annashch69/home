using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using NUnit.Framework;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.ApplicationServices;




namespace home
{
    [TestClass]
    public class PasswordRequirementsTests
    {
        [TestClass]
        public class Form1Tests
        {



            [TestMethod]
            public void ValidatePassword_TooShort_ReturnsFalse()
            {
                // Arrange
                string password = "Abc12";

                // Act
                bool isValid = PasswordValidator.ValidatePassword(password);

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(isValid);
            }

            [TestMethod]
            public void ValidatePassword_TooFewDigits_ReturnsFalse()
            {
                // Arrange
                string password = "Abc@def";

                // Act
                bool isValid = PasswordValidator.ValidatePassword(password);

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(isValid);
            }

            [TestMethod]
            public void ValidatePassword_TooFewLetters_ReturnsFalse()
            {
                // Arrange
                string password = "123@456";

                // Act
                bool isValid = PasswordValidator.ValidatePassword(password);

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(isValid);
            }

            [TestMethod]
            public void ValidatePassword_NoSpecialCharacters_ReturnsFalse()
            {
                // Arrange
                string password = "Abc123";

                // Act
                bool isValid = PasswordValidator.ValidatePassword(password);

                // Assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(isValid);
            }
        }
        public static class PasswordValidator
        {
            public static bool ValidatePassword(string password)
            {
                // Проверка требований к паролю
                return password.Length >= 5 &&
                       CountDigits(password) >= 3 &&
                       CountLetters(password) >= 5 &&
                       ContainsSpecialCharacters(password);
            }

            private static int CountDigits(string input)
            {
                return input.Count(char.IsDigit);
            }

            private static int CountLetters(string input)
            {
                return input.Count(char.IsLetter);
            }

            private static bool ContainsSpecialCharacters(string input)
            {
                char[] specialCharacters = { '@', '#', '%', ')', '(', '.', '<' };
                return input.IndexOfAny(specialCharacters) != -1;
            }
        }
    }
}
    
