using System;
using System.Linq;
using UnityEngine;
using TMPro;

public class GenerateNewProfileCode : MonoBehaviour
{
    [SerializeField]
    TMP_InputField[] personalInformationInputFields;
    public string code;

    static int GenerateCode(string[] PersonalInformation)
    {
        string ConcatenatedString = string.Empty;

        Array.ForEach(PersonalInformation, piece => ConcatenatedString += piece);

        return Math.Abs(Encipher(ConcatenatedString).GetHashCode());
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

    public void GetCode()
    {
        string[] information = new string[3];
        Array.ForEach(personalInformationInputFields, field => information.Append(field.text));
        code = GenerateCode(information).ToString();
    }
}
