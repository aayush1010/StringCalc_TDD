using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public class StringCalculator
    {
        public int Calculate(string input)
        {
            var delimiters = new List<string> { ",", "\n" };
            if (string.IsNullOrEmpty(input.Trim()))
            {
                return 0;
            }

            if (input.StartsWith("//"))
            {
                if (input.StartsWith("//["))
                {
                    delimiters.AddRange(input.Split("\n").First().Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    delimiters.Add(input.Substring(2, 1));
                }
                input = input.Split("\n").Last();
            }

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None).Select(x => int.Parse(x));

            var negativeNumbers = numbers.Where(x => x < 0);
            if (negativeNumbers.Any())
            {
                throw new Exception("Negatives Not Allowed" + string.Join(',', negativeNumbers));
            }

            return numbers.Where(x => x < 1000).Sum();
        }
    }
}
