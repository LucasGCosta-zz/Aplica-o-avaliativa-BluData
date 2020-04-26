using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BluData.Avaliacao.App.Extensions
{
    public static class StringExtensions
    {
        public static string OnlyNumbers(this string source)
        {
            return String.Join("", source.Where(char.IsNumber));
        }
    }
}
