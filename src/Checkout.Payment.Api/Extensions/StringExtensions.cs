using System;
using System.Text.RegularExpressions;

namespace Checkout.Payment.Api.Extensions
{
    public static class StringExtensions
    {
        public static string Mask(this string cardNumber)
        {
            var firstDigits = cardNumber.Substring(0, 6);
            var lastDigits = cardNumber.Substring(cardNumber.Length - 4, 4);

            var requiredMask = new String('X', cardNumber.Length - firstDigits.Length - lastDigits.Length);

            var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
            return Regex.Replace(maskedString, ".{4}", "$0 ");
        }
    }
}
