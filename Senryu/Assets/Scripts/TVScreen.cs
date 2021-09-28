using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScreen : MonoBehaviour
{

    [SerializeField] Material[] gameScreens;
    private int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayTV());
    }

    IEnumerator PlayTV()
    {
        yield return new WaitForSeconds(1);
        GetComponent<MeshRenderer>().material = gameScreens[counter];
        counter++;
        if(counter > 6)
        {
            counter = 0;
        }
        StartCoroutine(PlayTV());
    }
}
