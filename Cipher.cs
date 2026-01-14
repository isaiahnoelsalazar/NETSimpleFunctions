namespace NETSimpleFunctions
{
    public class Cipher
    {
        static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string TranspositionCipher(string text)
        {
            text = text.Replace(" ", "");
            string temp = "";
            string temp1 = "";
            int counter = 0;
            while (counter < text.Length)
            {
                if (counter % 2 == 0)
                {
                    temp += text.ToUpper()[counter].ToString().ToUpper();
                }
                else
                {
                    temp1 += text.ToUpper()[counter].ToString().ToUpper();
                }
                counter++;
            }
            return temp + temp1;
        }

        public static string GiovanniCipher(string text, string keyword, string keyLetter)
        {
            string temp = "";
            string temp1 = "";
            string temp2 = "";
            string cipher = "";
            for (int a = 0; a < keyword.ToUpper().Length; a++)
            {
                if (!temp.Contains(keyword.ToUpper()[a]))
                {
                    temp += keyword.ToUpper()[a];
                }
            }
            temp1 = temp;
            for (int a = 0; a < alphabet.Length; a++)
            {
                if (!temp1.Contains(alphabet[a]))
                {
                    temp1 += alphabet[a];
                }
            }
            for (int a = temp1.Length - alphabet.IndexOf(keyLetter.ToUpper()); a < temp1.Length; a++)
            {
                temp2 += temp1[a];
            }
            for (int a = 0; a < temp1.Length - alphabet.IndexOf(keyLetter.ToUpper()); a++)
            {
                temp2 += temp1[a];
            }
            for (int a = 0; a < text.ToUpper().Length; a++)
            {
                if (text.ToUpper()[a] == ' ')
                {
                    cipher += " ";
                }
                else if (!alphabet.Contains(text.ToUpper()[a]))
                {
                    cipher += text.ToUpper()[a];
                }
                else
                {
                    for (int b = 0; b < alphabet.Length; b++)
                    {
                        if (text.ToUpper()[a] == alphabet[b])
                        {
                            cipher += temp2[b];
                        }
                    }
                }
            }
            return cipher;
        }

        public static string KeywordCipher(string text, string keyword)
        {
            string temp = "";
            string temp1 = "";
            string cipher = "";
            for (int a = 0; a < keyword.ToUpper().Length; a++)
            {
                if (!temp.Contains(keyword.ToUpper()[a]))
                {
                    temp += keyword.ToUpper()[a];
                }
            }
            temp1 = temp;
            for (int a = 0; a < alphabet.Length; a++)
            {
                if (!temp1.Contains(alphabet[a]))
                {
                    temp1 += alphabet[a];
                }
            }
            for (int a = 0; a < text.ToUpper().Length; a++)
            {
                if (text.ToUpper()[a] == ' ')
                {
                    cipher += " ";
                }
                else if (!alphabet.Contains(text.ToUpper()[a]))
                {
                    cipher += text.ToUpper()[a];
                }
                else
                {
                    for (int b = 0; b < alphabet.Length; b++)
                    {
                        if (text.ToUpper()[a] == alphabet[b])
                        {
                            cipher += temp1[b];
                        }
                    }
                }
            }
            return cipher;
        }

        public static string CaesarCipher(string text, int shift)
        {
            string temp = "";
            string cipher = "";
            for (int a = shift; a < alphabet.Length; a++)
            {
                temp += alphabet[a];
            }
            for (int a = 0; a < shift; a++)
            {
                temp += alphabet[a];
            }
            for (int a = 0; a < text.ToUpper().Length; a++)
            {
                if (text.ToUpper()[a] == ' ')
                {
                    cipher += " ";
                }
                else if (!alphabet.Contains(text.ToUpper()[a]))
                {
                    cipher += text.ToUpper()[a];
                }
                else
                {
                    for (int b = 0; b < alphabet.Length; b++)
                    {
                        if (text.ToUpper()[a] == alphabet[b])
                        {
                            cipher += temp[b];
                        }
                    }
                }
            }
            return cipher;
        }
    }
}
