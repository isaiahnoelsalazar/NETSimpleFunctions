using System.Text;

namespace NETSimpleFunctions
{
    public class Convert
    {
        public static string Reverse(string s)
        {
            string Temp = string.Empty;
            for (int a = s.Length - 1; a > -1; a--)
            {
                Temp += s.ElementAt(a);
            }
            return Temp;
        }

        public static string ToBase64(string s)
        {
            return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
        }

        public static string FromBase64(string s)
        {
            return Encoding.UTF8.GetString(System.Convert.FromBase64String(s));
        }

        public static byte[] ToByteArray(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string FromByteArray(byte[] b)
        {
            return Encoding.UTF8.GetString(b);
        }

        // Note:
        // I have not tested the functions below. Proceed with caution.

        public static string FromHex(string s)
        {
            string Temp = string.Empty;
            for (int a = 0; a < s.Length; a += 2)
            {
                string b = s.Substring(a, 2);
                Temp += (char)System.Convert.ToByte(b, 16);
            }
            return Temp;
        }

        public static string FromBinary(string s)
        {
            string Temp = string.Empty;
            for (int a = 0; a < s.Length; a += 8)
            {
                string b = s.Substring(a, 8);
                Temp += (char)System.Convert.ToByte(b, 2);
            }
            return Temp;
        }

        public static string ToBinary(string s)
        {
            string Temp = string.Empty;
            foreach (char c in s)
            {
                Temp += System.Convert.ToString(c, 2).PadLeft(8, '0');
            }
            return Temp;
        }

        public static string ToHex(string s)
        {
            StringBuilder Temp = new StringBuilder();
            foreach (char c in s)
            {
                Temp.AppendFormat("{0:X2}", (int)c);
            }
            return Temp.ToString();
        }

        public static int ToInt(string s)
        {
            return int.Parse(s);
        }

        public static double ToDouble(string s)
        {
            return double.Parse(s);
        }

        public static long ToLong(string s)
        {
            return long.Parse(s);
        }

        public static float ToFloat(string s)
        {
            return float.Parse(s);
        }
    }
}
