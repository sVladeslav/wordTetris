using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


public class Word : MonoBehaviour
{
    string wordQuestion = "";
    readonly string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    public List<int> TrueLettersIndex { get; set; }

    public void SetWord(string word)
    {
        wordQuestion = word.ToLower();
        TrueLettersIndex = new List<int>();
        foreach (var letter in wordQuestion)
        {
            TrueLettersIndex.Add(alphabet.IndexOf(letter));
        }
    }

    public GameObject CreateLetterOnScene(Vector3 position)
    {
        int randomNumber = UnityEngine.Random.Range(0, TrueLettersIndex.Count);
        int randomLetter = TrueLettersIndex[randomNumber];
        
        GameObject letter = Resources.Load($"alphabet/alphabet_{randomLetter.ToString()}") as GameObject;
        return Instantiate(letter, position ,Quaternion.identity);
    }
}

