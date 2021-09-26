using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextLoader : MonoBehaviour
{
    [SerializeField] Animator mainPanel;
    [SerializeField] Animator firstTextAnim;
    [SerializeField] Animator secondHeadingAnim;
    [SerializeField] Animator poem1;
    [SerializeField] Animator poem2;
    [SerializeField] Animator poem3;
    [SerializeField] GameObject thirdText;
    [SerializeField] GameObject fourthText;
    [SerializeField] TutorialSceneManager sceneManagement;

    [SerializeField] float waitFirstTextLeave = 5f;
    [SerializeField] float poem1ReadingTime = 5f;
    [SerializeField] float poem2ReadingTime = 5f;
    [SerializeField] float poem3ReadingTime = 5f;

    void Start()
    {
        //Scene starts with first text fading in
        //Wait a while before changing
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        //Wait then fade out first text
        yield return new WaitForSeconds(waitFirstTextLeave);
        firstTextAnim.SetTrigger("FadeOutStart");

        //Wait two seconds
        yield return new WaitForSeconds(2);

        //Fade in secondTextHeading
        secondHeadingAnim.SetTrigger("FadeInSecondHead");

        yield return new WaitForSeconds(2);
        poem1.SetTrigger("FadeInPoem1");

        yield return new WaitForSeconds(poem1ReadingTime);
        poem2.SetTrigger("FadeInPoem2");

        yield return new WaitForSeconds(poem2ReadingTime);
        poem3.SetTrigger("FadeInPoem3");

        yield return new WaitForSeconds(poem3ReadingTime);
        secondHeadingAnim.SetTrigger("FadeOutSecondHead");
        poem1.SetTrigger("FadeOutPoem1");
        poem2.SetTrigger("FadeOutPoem2");
        poem3.SetTrigger("FadeOutPoem3");

        yield return new WaitForSeconds(2f);
        thirdText.SetActive(true);
        yield return new WaitForSeconds(10f);
        thirdText.GetComponent<Animator>().SetTrigger("FadeInThirdTile");

        yield return new WaitForSeconds(2f);
        thirdText.SetActive(false);
        fourthText.SetActive(true);
        yield return new WaitForSeconds(10f);
        fourthText.GetComponent<Animator>().SetTrigger("FadeInSecondPanel");

        yield return new WaitForSeconds(2f);
        sceneManagement.PlayNextScene();

    }

}
