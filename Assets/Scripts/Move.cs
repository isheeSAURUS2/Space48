using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 25f;
    enum moveType{player, bullet};
    [SerializeField] moveType moveTypeSelecter;
    float dir;
    
    public void DoMove(float dir, GameObject gameObjectToMove, float speed)
    {
        gameObjectToMove.transform.position = gameObjectToMove.transform.position + transform.forward * speed * dir * Time.deltaTime;

    }
    void Rotate()
    {
        if (moveTypeSelecter == moveType.player) {
            transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTypeSelecter == moveType.player) {
            dir = Input.GetAxis("Vertical");
        }
        else
        {
            dir = 1;
        }
        DoMove(dir, gameObject, moveSpeed);
        Rotate();
    }
}
