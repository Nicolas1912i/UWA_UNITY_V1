using System;
using System.Linq;
using UnityEngine;
using TMPro;

public class GenerateNewProfileCode : MonoBehaviour
{
    [SerializeField] TMP_InputField[] personalInformationInputFields;
    [HideInInspector] public string code;

    static int GenerateCode(string[] personalInformation)
    {
        string concatenatedString = string.Empty;
        Array.ForEach(personalInformation, piece => concatenatedString += piece);
        return Math.Abs(Encipher(concatenatedString).GetHashCode());
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
        string output = string.Empty;
        foreach (char ch in Text)
            output += Cipher(ch);
        return output;
    }

    public void GetCode()
    {
        string[] information = new string[3];
        Array.ForEach(personalInformationInputFields, field => information.Append(field.text));
        code = GenerateCode(information).ToString();
    }
}
