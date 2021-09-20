using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Animator transitionAnim;
    public Animator soundAnim;
    public Animator musicAnim;
    public float waitTime = 10f;

    [SerializeField] GameObject startSounds;

    public void Start()
    {
        startSounds.SetActive(true);
    }

    public void PlayGame()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        musicAnim.SetTrigger("FadeOut");
        soundAnim.SetTrigger("FadeOut");
        transitionAnim.SetTrigger("endPlay");
        
        yield return new WaitForSeconds(waitTime);
        startSounds.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
