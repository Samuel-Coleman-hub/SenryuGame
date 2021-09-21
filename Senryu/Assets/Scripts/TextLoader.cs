using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : MonoBehaviour
{
    [SerializeField] Animator textAnim;
    
    [SerializeField] float waitFirstTextLeave = 5f;
    
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
        textAnim.SetTrigger("FadeOutStart");

        //Wait two seconds
        yield return new WaitForSeconds(2);

        //Fade in secondTextHeading
        textAnim.SetTrigger("FadeInSecondHead");

    }

}
