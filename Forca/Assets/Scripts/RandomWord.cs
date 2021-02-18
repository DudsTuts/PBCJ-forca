using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class RandomWord
{
    private static List<string> words;          // Variavel para uso de lista.
    public static string getWords()             // Funcao que retorna uma palavra aleatoria dentre uma lista de palavras.
    {
        if (words == null)
        {
            initWords();
        }
        return words[Random.Range(0, words.Count)];
    }
    static void initWords()                     // Funcao que atribui uma serie de palavras em uma lista.
    {
        string path = "Assets/Resources/test.txt";
        StreamReader reader = new StreamReader(path);
        words = new List<string>();

        string line;
        while ( (line=reader.ReadLine()) != null) {
            words.Add(line.ToUpper());
        }
    }
}