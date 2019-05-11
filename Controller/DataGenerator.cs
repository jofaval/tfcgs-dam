using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DataGenerator
    {
        public DataGenerator()
        {
            if (RandomGenerator == null)
            {
    
            }
        }

        public const int MaxHoursDayInSeconds = 24 * 60 * 60;
        public const int MayusStartAt = 'A';
        public const int MaxPasswordLen = 32;

        public const string FirstNameFilename = "FirstName.csv";
        public const string SurNameFilename = "SurName.csv";

        public char[] PasswordChar = "ABCDEFGHIJKLMÑNOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789*_-".ToCharArray();

        public const char RowDelimiter = '\n';
        public const char CellDelimiter = ',';

        public const int FirstNameColWithData = 1;
        public const int SurNameColWithData = 0;

        public const int StartAtRow = 1;

        public static List<string> FirstNamesList = new List<string>();
        public static int LenFirstName { get; set; }
        public static List<string> SurNamesList = new List<string>();
        public static int LenSurName { get; set; }

        public string GenerateNIF()
        {
            int letterNum = RandomGenerator.Next(0, 26);


            var number = RandomGenerator.Next(9999999);
            var letra = (char)(letterNum + MayusStartAt);

            return 'K' + number.ToString("D7") + letra;
        }

        readonly List<string> EmailProviders = new List<string>()
        {
            "gmail",
            "google",
            "yahoo",
            "hotmail",
            "outlook"
        };

        readonly List<string> EmailDomains = new List<string>()
        {
            "com",
            "es",
            "com.es",
            "org",
            "io"
        };

        public static Random RandomGenerator { get; set; }

        public const int MaxDNINumber = 99999999;

        public static DataGenerator Instance;

        public static DataGenerator GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DataGenerator();
                var dataPath = Path.Combine(
                    Directory.GetParent(
    Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                    "Controller",
                    "Data"
                    );
                var firstnameCSVData = File.ReadAllText(Path.Combine(dataPath, FirstNameFilename)).Split(RowDelimiter);
                var lenFirstnameCSVData = firstnameCSVData.Length;
                LenFirstName = lenFirstnameCSVData - 1;
                for (int rowIterator = StartAtRow; rowIterator < lenFirstnameCSVData; rowIterator++)
                {
                    var firstnameCSVRow = firstnameCSVData[rowIterator].Split(CellDelimiter);
                    var firstname = firstnameCSVRow[FirstNameColWithData].Replace("\"", "");
                    FirstNamesList.Add(Captilize(firstname));
                }

                var surnameCSVData = File.ReadAllText(Path.Combine(dataPath, SurNameFilename)).Split(RowDelimiter);
                var lenSurnameCSVData = surnameCSVData.Length;
                LenSurName = lenSurnameCSVData - 1;
                for (int rowIterator = StartAtRow; rowIterator < lenSurnameCSVData; rowIterator++)
                {
                    var surnameCSVRow = surnameCSVData[rowIterator].Split(CellDelimiter);
                    var surname = surnameCSVRow[SurNameColWithData];
                    SurNamesList.Add(Captilize(surname));
                }

                RandomGenerator = new Random(DateTime.Now.Millisecond);
            }
            return Instance;
        }

        public string GenerateName()
        {
            var firstName = GenerateFirstName();
            var surName = GenerateSurName() + " " + GenerateSurName();
            return firstName + " " + surName;
        }

        public string GenerateFirstName()
        {

            return FirstNamesList.ElementAt(RandomGenerator.Next(LenFirstName));
        }

        public string GenerateSurName()
        {

            return SurNamesList.ElementAt(RandomGenerator.Next(LenSurName));
        }

        public static string Captilize(string nameSource)
        {
            var names = nameSource.Split(' ');
            var lenNames = names.Length;
            var stringBuilder = new StringBuilder();
            for (int nameIterator = 0; nameIterator < lenNames; nameIterator++)
            {
                var name = names[nameIterator].ToCharArray();
                var lenName = name.Length;
                name[0] = char.ToUpper(name[0]);
                for (int charNAmeIterator = 1; charNAmeIterator < lenName; charNAmeIterator++)
                {
                    name[charNAmeIterator] = char.ToLower(name[charNAmeIterator]);
                }
                stringBuilder.Append(new string(name) + " ");
            }
            stringBuilder.Length--;
            return stringBuilder.ToString();
        }

        public string GenerateDNI()
        {
            var dniNumber = RandomGenerator.Next(MaxDNINumber);
            var resto = dniNumber % 23;

            return dniNumber.ToString("D8") + (DNILeterEnum)resto;
        }

        public bool CheckDniIsCorrect(string dni)
        {
            if (dni.Length == 9)
            {
                if (!dni.All(char.IsLetterOrDigit))
                {
                    return false;
                }
                if (dni.All(char.IsDigit) || dni.All(char.IsDigit))
                {
                    return false;
                }
                string numeros = dni.Substring(0, 8);
                if (!numeros.All(char.IsDigit))
                {
                    return false;
                }
                var resto = int.Parse(dni.Substring(0, 8)) % 23;
                var letraOrigin = char.ToUpper(dni.ElementAt(8));

                return letraOrigin.Equals((DNILeterEnum)resto);
            }
            return false;
        }

        public string GenerateEmail(string fullname)
        {

            return fullname.Replace(' ', '.')
                + '@' + EmailProviders.ElementAt(RandomGenerator.Next(EmailProviders.Count))
                + '.' + EmailDomains.ElementAt(RandomGenerator.Next(EmailDomains.Count));
        }

        public string GenerateEmail()
        {
            return GenerateEmail(GenerateName());
        }

        public string GenerateUsername(string fullname)
        {
            var names = fullname.Split(' ');
            return names[0] + ' ' + names[1];
        }

        public string GenerateUsername()
        {
            return GenerateUsername(GenerateName());
        }

        public string GeneratePassword()
        {
            var password = "";
            var passCharsLen = PasswordChar.Length;

            for (int charIterator = 0; charIterator < MaxPasswordLen; charIterator++)
            {
                password += PasswordChar[RandomGenerator.Next(passCharsLen)];
            }

            return password;
        }

        public DateTime RandomDate(int startAtYear = 1900)
        {
            var newDate = new DateTime(startAtYear, 1, 1, 0, 0, 0);

            int range = (DateTime.Today - newDate).Days;
            //RandomGenerator = new Random(DateTime.Now.Millisecond);
            newDate = newDate.AddDays(
                RandomGenerator.Next(
                    range
                    )
                    );

            //RandomGenerator = new Random(DateTime.Now.Millisecond);
            newDate = newDate.AddSeconds(
                RandomGenerator.Next(
                    MaxHoursDayInSeconds
                    )
                    );

            return newDate;
        }

        public int RandomNumberBetween(int end, int start = 0)
        {
            RandomGenerator = new Random(DateTime.Now.Millisecond);
            return RandomGenerator.Next(start, end);
        }
    }
}
