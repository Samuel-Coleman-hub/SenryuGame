using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalkingMan : MonoBehaviour
{
    [SerializeField] GameObject man;
    [SerializeField] Transform spawnTransform;
    [SerializeField] float timeBetweenSpawn = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMan());
    }

    IEnumerator SpawnMan()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        Instantiate(man, spawnTransform.position, Quaternion.Euler(gameObject.transform.rotation.eulerAngles));
        StartCoroutine(SpawnMan());
    }

}
