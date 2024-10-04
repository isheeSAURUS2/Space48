using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject laserPrefab;
    public float cooldownTime = 3f;
    private float cooldownCounter = 0f;
    private void Update()
    {
        ShootLoop();
    }
    void ShootLoop()
    {
        cooldownCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            laser.GetComponent<LaserBehaviour>().Ship = gameObject;
            Destroy(laser, 3f);

            cooldownCounter = 0f;

        }


    }
}
