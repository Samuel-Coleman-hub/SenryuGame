using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneManager : MonoBehaviour
{
    public Animator musicAnim;
    public Animator panelAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayNextScene()
    {
        StartCoroutine(PlayNext());
    }

    IEnumerator PlayNext()
    {
        musicAnim.SetTrigger("FadeOutMusic");
        panelAnim.SetTrigger("ToNewColour");

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
