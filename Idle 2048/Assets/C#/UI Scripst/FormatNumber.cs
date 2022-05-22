using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class FormatNumber : MonoBehaviour
{
    private string[] words = new string[] { "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion", "Nonillion", "Decillion", "Undecillion", "Duodecillion", "Tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septendecillion", "Octodecillion", "Novemdecillion", "Vigintillion", "Unvigintillion", "Duovigintillion", "Tresvigintillion", "Quattuorvigintillion", "Quinquavigintillion", "Sesvigintillion", "Septemvigintillion", "Octovigintillion", "Novemvigintillion", "Trigintillion", "Untrigintillion", "Duotrigintillion", "Duotrigintillion", "Trestrigintillion", "Quattuortrigintillion", "Quinquatrigintillion", "Sestrigintillion", "Septentrigintillion", "Octotrigintillion", "Noventrigintillion", "Quadragintillion" };
    private string[] letters = new string[] { "K", "M", "B", "T", "q", "Q", "s", "S", "O", "N", "d", "U", "D", "!", "£", "$", "%", "µ", "&", "*", "@", "#", "±", "?", "¥", "§", "¢", "Ç", "¿", "Ʃ" };

    public string formatNumber(long number, bool word = false)
    {
        bool highNum = false;
        int pos = -1;
        long formatNum = number;

        if (formatNum >= 1000) { highNum = true; }

        while (formatNum >= 1000) { formatNum /= 1000; pos++; }

        if (!highNum) { return number.ToString(); }

        string output = number.ToString("F0").Substring(0, 3);

        if (word) { output = output + words[pos]; }
        else { output = output + letters[pos]; }

        if (formatNum < 10) { return output.Insert(1, "."); }
        if (formatNum < 100) { return output.Insert(2, "."); }
        return output;
    }

    public string formatNumber(float number, bool word = false)
    {
        bool highNum = false;
        int pos = -1;
        int formatNum = (int)number;
        int originalNumber = formatNum;

        if (formatNum >= 1000) { highNum = true; }

        while (formatNum >= 1000) { formatNum /= 1000; pos++; }

        if (!highNum) { return originalNumber.ToString(); }

        string output = originalNumber.ToString("F0").Substring(0, 3);

        if (word) { output = output + words[pos]; }
        else { output = output + letters[pos]; }

        if (formatNum < 10) { return output.Insert(1, "."); }
        if (formatNum < 100) { return output.Insert(2, "."); }
        return output;
    }

    public string formatNumberBigNumber(BigInteger number, bool word = false)
    {
        bool highNum = false;
        int pos = -1;
        BigInteger formatNum = new BigInteger((int)number);
        BigInteger originalNumber = new BigInteger((int)number);

        if (formatNum >= 1000) { highNum = true; }

        while (formatNum >= 1000) { formatNum /= 1000; pos++; }

        if (!highNum) { return originalNumber.ToString(); }

        string output = originalNumber.ToString("F0").Substring(0, 3);

        if (word) { output = output + words[pos]; }
        else { output = output + letters[pos]; }

        if (formatNum < 10) { return output.Insert(1, "."); }
        if (formatNum < 100) { return output.Insert(2, "."); }
        return output;
    }
}
