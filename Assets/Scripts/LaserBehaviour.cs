using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 500;
    [HideInInspector] public GameObject Ship;
    private float dir = 1;
    private void Update()
    {
        Ship.GetComponent<Move>().DoMove(dir, gameObject, moveSpeed);
    }



}
