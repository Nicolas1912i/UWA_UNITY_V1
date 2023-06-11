using System;
using UnityEngine;

public class GenerateNewProfileCode : MonoBehaviour
{

    string Name, Age, School;

    static int GenerateCode(string[] PersonalInformation)
    {
        string ConcatenatedString = string.Empty;

        Array.ForEach(PersonalInformation, piece => ConcatenatedString += piece);

        return Encipher(ConcatenatedString).GetHashCode();
    }

    static char Cipher(char ch)
    {
        if (!char.IsLetter(ch))
            return ch;

        char k = char.IsUpper(ch) ? 'A' : 'a';
        return (char)((((ch + 5) - k) % 26) + k);
    }


    static string Encipher(string Text)
    {
        string Output = string.Empty;

        foreach (char ch in Text)
            Output += Cipher(ch);

        return Output;
    }
}
