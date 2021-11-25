using System.Text.RegularExpressions;

namespace Packet.Shared
{
    //使用静态方法重用功能
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            return Regex.IsMatch(input, @"[a-zA-z0-9\._]+@[a-zA-Z0-9\.-_]+");
        }
    }
} 