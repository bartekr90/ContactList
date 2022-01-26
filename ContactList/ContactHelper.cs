using System.Collections.Generic;

namespace ContactList
{
    public static class ContactHelper
    {
        public static List<string> TypeList = new List<string>
        {
            "Prywatny",
            "Firmowy"
        };
        
        /// <summary>
        /// Filters characters based on ASCII decimal values, can return empty string.
        /// </summary>
        /// <param name="data">This data will be checked</param>        
        /// <param name="length">Limit length of string</param>
        /// <returns></returns>
        public static string LetterValidation(string data, int length = 25)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            char[] text = data.ToCharArray(); 
            byte castSign;

            foreach (var keySign in text)
            {
                castSign = (byte)keySign;

                if (castSign == 27)
                    goto Clear;

                if (castSign == 8)
                    goto Remove;

                if (castSign == 13)
                    goto ReturnString;

                if (castSign == 38 ||
                    castSign == 45 ||
                    castSign == 46 ||
                    (castSign > 63 && castSign < 91) || 
                    (castSign > 96 && castSign < 123) || 
                    (castSign > 127 && castSign < 168))
                    goto Append;

                else
                    goto NotAppend;

                ReturnString:
                break;

            Append:
                if (sb.Length < length)
                {
                    sb.Append(keySign);
                }
                continue;

            NotAppend:
                continue;

            Remove:

                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
                continue;

            Clear:
                sb.Clear();
                continue;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Filters characters based on ASCII decimal values, accepts only digits, can return empty string.
        /// </summary>
        /// <param name="data">This data will be checked</param>        
        /// <param name="length">Limit length of string</param>
        /// <returns></returns>
        public static string NumberValidation(string data, int length = 25)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            char[] text = data.ToCharArray();
            byte castSign;

            foreach (var keySign in text)
            {
                castSign = (byte)keySign;

                if (castSign == 27)
                    goto Clear;

                if (castSign == 8)
                    goto Remove;

                if (castSign == 13)
                    goto ReturnString;

                if (castSign > 47 && castSign < 58) 
                    goto Append;

                else
                    goto NotAppend;

                ReturnString:
                break;

            Append:
                if (sb.Length < length)
                {
                    sb.Append(keySign);
                }
                continue;

            NotAppend:
                continue;

            Remove:

                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
                continue;

            Clear:
                sb.Clear();
                continue;
            }
            return sb.ToString();
        }
    }
}
