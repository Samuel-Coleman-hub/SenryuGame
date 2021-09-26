using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int envCount = 3;
    private int envActive = 1;

    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject cam3;

    [SerializeField] GameObject envSounds1;
    [SerializeField] GameObject envSounds2;
    [SerializeField] GameObject envSounds3;

    [SerializeField] GameObject inputLine1;
    [SerializeField] GameObject inputLine2;
    [SerializeField] GameObject inputLine3;

    [SerializeField] GameObject floatingTexts;

    [SerializeField] int poemsOnScreen = 10;

    DatabaseHandler databaseHandler = new DatabaseHandler();

    // Start is called before the first frame update
    void Start()
    {
        GetPoems();
    }

    public void RightButton()
    {
        if (envActive < envCount)
        {
            envActive++;
            Debug.Log("enoActive is now" + envActive);
            SwitchEnviroment(envActive);

        }
    }

    public void LeftButton()
    {
        if (envActive > 1)
        {
            envActive--;

            SwitchEnviroment(envActive);
        }
    }

    private void SwitchCamera(int num)
    {
        switch (num)
        {
            case 1:
                cam1.SetActive(true);
                cam2.SetActive(false);
                cam3.SetActive(false);
                break;

            case 2:
                cam1.SetActive(false);
                cam2.SetActive(true);
                cam3.SetActive(false);
                break;

            case 3:
                cam1.SetActive(false);
                cam2.SetActive(false);
                cam3.SetActive(true);
                break;
        }
    }

    private void SwitchMusic(int num)
    {
        switch (num)
        {
            case 1:
                envSounds1.SetActive(true);
                envSounds2.SetActive(false);
                envSounds3.SetActive(false);
                break;

            case 2:
                envSounds1.SetActive(false);
                envSounds2.SetActive(true);
                envSounds3.SetActive(false);
                break;

            case 3:
                envSounds1.SetActive(false);
                envSounds2.SetActive(false);
                envSounds3.SetActive(true);
                break;

        }
    }

    private void SwitchEnviroment(int num)
    {
        SwitchCamera(num);
        SwitchMusic(num);
        GetPoems();

    }

    private void GetPoems()
    {
        DatabaseHandler.GetPoems(poems =>
        {
            GetRandomPoems(poems);
        });
    }

    private void GetRandomPoems(Dictionary<string, Poem> poems)
    {
        Debug.Log("in getRandomPoems");
        List<int> finalPoemList = CuratePoemList(poems);
        Debug.Log("This is count "+ finalPoemList.Count);
        foreach(int x in finalPoemList)
        {
            Debug.Log(x);
        }
        PopulateTextFields(poems, finalPoemList);
    }

    private List<int> CuratePoemList(Dictionary<string, Poem> poems)
    {
        List<int> randomList = CreateRandomList(poems);
        List<int> finalPoemList = new List<int>();
        int i = 0;
        while (finalPoemList.Count < poemsOnScreen)
        {
            Debug.Log("Loop " + i);
            if (!randomList.Any() || i >= poems.Count || i >= randomList.Count)
            {
                Debug.Log("Worked to return");
                return finalPoemList;
            }
            if (poems.ElementAt(randomList.ElementAt(i)).Value.poemEnviroment == envActive)
            {
                Debug.Log("Poem works");
                finalPoemList.Add(randomList.ElementAt(i));
                randomList.RemoveAt(i);
            }
            

            i++;
        }
        Debug.Log("Returned by default");
        return finalPoemList;
        
    }

    private List<int> CreateRandomList(Dictionary<string, Poem> poems)
    {
        List<int> randNums = new List<int>();
        for (int i = 0; i < 200; i++)
        {
            int numToAdd = Random.Range(0, poems.Count);
            while (randNums.Contains(numToAdd))
            {
                numToAdd = Random.Range(0, poems.Count);
            }
            randNums.Add(numToAdd);
            if (randNums.Count >= poems.Count)
            {
                return randNums;
            }
        }
        return randNums;
    }

    private void PopulateTextFields(Dictionary<string, Poem> poems, List<int> randNums)
    {
        int counter = 0;
        foreach(Transform child in floatingTexts.transform)
        {
            string poemContents = poems.ElementAt(randNums.ElementAt(counter))
                .Value.poemContents;
            child.gameObject.GetComponent<TMP_Text>().text = poemContents;
            counter++;
        }
    }

    public void UploadPoem()
    {
        string poemContent = inputLine1.GetComponent<TMP_InputField>().text + "\n"
            + inputLine2.GetComponent<TMP_InputField>().text + "\n"
            + inputLine3.GetComponent<TMP_InputField>().text + "\n";

        Poem poem = new Poem(poemContent, "untitled", "unknown", envActive);
        databaseHandler.PostPoem(poem, () =>
        {
            Debug.Log("poem uploaded");
        });

        inputLine1.GetComponent<TMP_InputField>().text = "";
        inputLine2.GetComponent<TMP_InputField>().text = "";
        inputLine3.GetComponent<TMP_InputField>().text = "";

    }
}
