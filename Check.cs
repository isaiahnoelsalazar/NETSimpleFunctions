using System.Text.RegularExpressions;

namespace NETSimpleFunctions
{
    public class Check
    {
        static string Numbers = "0123456789";
        static string Symbols = "~`!@#$%^&*()_+-=[]{}\\|'\";:,.<>/?";

        public static class Email
        {
            static Memory<string> ValidDomainNames = new Memory<string>();
            static Memory<string> ValidDomainExtensions = new Memory<string>();
            static Memory<string> ValidDomains = new Memory<string>();
            static bool ShouldUseFullDomainValue = false;

            public static void AddValidDomainName(string s)
            {
                ValidDomainNames.Add(s);
            }

            public static void AddValidDomainExtension(string s)
            {
                ValidDomainExtensions.Add(s);
            }

            public static void AddValidDomain(string s)
            {
                ValidDomains.Add(s);
            }

            public static void ShouldUseFullDomain()
            {
                ShouldUseFullDomainValue = true;
            }

            public static void ShouldUseFullDomain(bool b)
            {
                ShouldUseFullDomainValue = b;
            }

            public static bool IsValid(string s)
            {
                if (ShouldUseFullDomainValue)
                {
                    try
                    {
                        string[] Domain = s.Split('@');
                        return ValidDomains.Contains(Domain[1]);
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        string[] Domain = s.Split('@');
                        string DomainName = Domain[1].Split('.')[0];
                        string DomainExtension = Domain[1].Split('.')[1];
                        return ValidDomainNames.Contains(DomainName) && ValidDomainExtensions.Contains(DomainExtension);
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public static bool IsAValidPhilippineMobileNumber(string s)
        {
            string Pattern = @"^(?:09|\+639|639)\d{9}$";
            return Regex.IsMatch(Regex.Replace(s, @"[\s\-\(\)]", ""), Pattern);
        }

        public static bool IsAllNumbers(string s)
        {
            bool Value = true;
            foreach (char a in s)
            {
                if (!Numbers.Contains(a))
                {
                    Value = false;
                }
            }
            return Value;
        }

        public static bool HasNumbers(string s)
        {
            foreach (char a in s)
            {
                foreach (char b in Numbers)
                {
                    if (a == b)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool HasSymbols(string s)
        {
            foreach (char a in s)
            {
                foreach (char b in Symbols)
                {
                    if (a == b)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool HasSpaces(string s)
        {
            foreach (char a in s)
            {
                if (a == ' ')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
