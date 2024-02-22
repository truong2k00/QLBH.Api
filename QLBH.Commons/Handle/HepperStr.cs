using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Commons
{
    public class HepperStr
    {
        public static string ToFirstUpper(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            string result = "";

            //lấy danh sách các từ  

            string[] words = s.Split(' ');

            foreach (string word in words)
            {
                // từ nào là các khoảng trắng thừa thì bỏ  
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }
            }
            return result.Trim();
        }
        public static bool length(string password)
        {
            if (password.Length < 8 || password.Length > 14)
                return false;
            return true;
        }
        public static bool IsUpper(string password)
        {
            if (!password.Any(char.IsUpper))
                return false;
            else return true;
        }
        public static bool Islower(string password)
        {
            if (!password.Any(char.IsUpper))
                return false;
            else return true;
        }
        public static bool space(string password)
        {
            if (password.Contains(" "))
                return false;
            else return true;
        }
        public static bool Number(string password)
        {
            if (!password.Any(char.IsDigit))
                return false;
            else return true;
        }
        public static bool special_character(string password)
        {
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChArray = specialCh.ToCharArray();
            foreach (char ch in specialChArray)
            {
                if (password.Contains(ch))
                    return true;
            }
            return false;
        }
        public static Enums.Hepper CheckPass(string password)
        {
            if (!length(password))
                return Enums.Hepper.length;
            if (!IsUpper(password))
                return Enums.Hepper.IsUpper;
            if (!Islower(password))
                return Enums.Hepper.Islower;
            if (!space(password))
                return Enums.Hepper.space;
            if (!special_character(password))
                return Enums.Hepper.special_character;
            else return Enums.Hepper.Success;
        }
    }
}
