using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialUploader.Utilities
{
    public static class ExtractNumber
    {
        public static int GetNumber(string text)
        {
            bool digitFound = false;
            int index = 0;
            int result = 0;

            while (!digitFound)
            {
                char character = text[index];
                digitFound = char.IsDigit(character);

                if (!digitFound)
                    index++;
            }

            var numberPortiuon = text.Substring(index);

            if (int.TryParse(numberPortiuon, out result))
                return result;
            else return -1;

        }

    }
}
