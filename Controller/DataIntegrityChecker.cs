using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DataIntegrityChecker
    {
        public List<char> ProhibitedCharacters { get; set; }
        static public List<char> prohibitedCharacters = new List<char>()
        {
            '\'',
            ',',
            ';',
            '=',
            '"',
            '-',
            '+',
            '/'
        };
        static public IDictionary<string, string> UsernamePassword = new Dictionary<string, string>()
        {
            { "usuario", "a1234" }
        };

        static public int MinCharLen = 3;
        static public int MaxCharLen = 16;
        static public int LenProhibitedCharacters = 8;

        public static bool CheckDataIntegrity(string dataString)
        {
            var dataCharArray = dataString.ToLower().ToCharArray();
            var lenDataCharArray = dataCharArray.Count();

            for (int prohibitedCharactersIterator = 0; prohibitedCharactersIterator < LenProhibitedCharacters; prohibitedCharactersIterator++)
            {
                var prohibitedCharacter = prohibitedCharacters.ElementAt(prohibitedCharactersIterator);
                for (int dataCharIterator = 0; dataCharIterator < lenDataCharArray; dataCharIterator++)
                {
                    if (dataCharArray[dataCharIterator] == prohibitedCharacter)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool CheckUsernameIntegrity(string username)
        {
            var lenUsername = username.Count();

            if (lenUsername <= MinCharLen || lenUsername >= MaxCharLen)
            {
                return false;
            }

            return CheckDataIntegrity(username);
        }

        public static int CheckPasswordStrengthLevel(string password)
        {
            var nivel = 0;
            var lenPassword = password.Length;
            if (CheckDataIntegrity(password))
            {
                if (lenPassword > MinCharLen)
                {
                    nivel++;
                }
                if (!password.All(char.IsLetterOrDigit))
                {
                    nivel++;
                }
                if (password.Any(char.IsDigit))
                {
                    nivel++;
                }
                if (password.Any(char.IsLetter))
                {
                    nivel++;
                    if (password.Any(char.IsUpper) && password.Any(char.IsLower))
                    {
                        nivel++;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

            return nivel;
        }

        public static bool CheckUsernamePassword(string username, string password)
        {
            if (CheckUsernameIntegrity(username) && CheckPasswordStrengthLevel(password) > 0)
            {
                if (UsernamePassword.ContainsKey(username))
                {
                    if (UsernamePassword[username].Equals(password))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CheckEmail(string email)
        {
            var realLen = email.Length - 1;
            if (email.Count(x => x == '@') == 1)
            {
                var indexAt = email.IndexOf('@');
                if (indexAt < realLen)
                {
                    var indexDot = email.LastIndexOf('.');
                    if (indexAt < indexDot)
                    {
                        return indexDot < realLen;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        public static bool FullyCheckIfContainsString(string maybeContains, string toBeContained, bool? ignoreMayus = true, bool? exactMatch = true)
        {
            if (ignoreMayus.Value)
            {
                maybeContains = maybeContains.ToLower();
                toBeContained = toBeContained.ToLower();
            }

            var maybeContainsCharArray = maybeContains.ToCharArray();
            var maybeContainsLen = maybeContains.Length;

            var toBeContainedCharArray = toBeContained.ToCharArray();
            var toBeContainedLen = toBeContained.Length;

            bool[] hits = new bool[toBeContainedLen];

            for (int maybeContainsCharIterator = 0; maybeContainsCharIterator < maybeContainsLen; maybeContainsCharIterator++)
            {
                var currentMaybeContainsChar = maybeContainsCharArray[maybeContainsCharIterator];
                if (hits.Any(b => !b))
                {
                    for (int toBeContainedCharIterator = 0; toBeContainedCharIterator < toBeContainedLen; toBeContainedCharIterator++)
                    {
                        if (currentMaybeContainsChar.Equals(toBeContained[toBeContainedCharIterator]))
                        {
                            hits[toBeContainedCharIterator] = true;
                            break;
                        }
                    }
                }
            }

            return hits.All(b => b);
        }
    }
}
