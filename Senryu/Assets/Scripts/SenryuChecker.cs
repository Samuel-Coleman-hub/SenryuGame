
using UnityEngine;
using TMPro;
using System.Linq;

public class SenryuChecker : MonoBehaviour
{
    [SerializeField] GameObject syllableCount;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void syllableUpdate()
    {
        string word = GetComponent<TMP_InputField>().text;
        string[] words = word.Split(' ');
        int count = 0;

        foreach(string x in words)
        {
            count += syllableCounter(x);
        }

        syllableCount.GetComponent<TMP_Text>().text = count.ToString();
    }

    private int syllableCounter(string word)
    {
        word = word.ToLower().Trim();

        int count = 0;
        bool previousVowel = false;
        var vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'y' };

        foreach (var c in word)
        {
            if (vowels.Contains(c))
            {
                if (!previousVowel)
                {
                    count++;
                    previousVowel = true;
                }
            }
            else
            {
                previousVowel = false;
            }
        }

        if ((word.EndsWith("e") || (word.EndsWith("es") || word.EndsWith("ed")))
          && !word.EndsWith("le"))
        {
            count--;
        }

        return count;
    }
}
