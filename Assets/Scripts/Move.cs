using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 25f;
    
    public void DoMove(float dir, GameObject gameObjectToMove, float speed)
    {
        gameObjectToMove.transform.position = gameObjectToMove.transform.position + transform.forward * speed * dir * Time.deltaTime;

    }
    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Vertical");
        DoMove(dir, gameObject, moveSpeed);
        Rotate();
    }
}
