using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 1;
    private void Update()
    {
        // Moves the object to target position
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }
}

