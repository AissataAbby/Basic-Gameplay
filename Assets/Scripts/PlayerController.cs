using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour

{ 
    [SerializeField] float speed = 20f;
    [SerializeField] float xRange = 10f;
    private float movementX;

    public GameObject projectilePrefab;


private void OnMove (InputValue movementValue)
    { 
    float movementVector = movementValue.Get<float>();
     movementX = movementVector;
    }

    void Update()
    //keep player inbounds
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }

        transform.Translate(Vector3.right * movementX * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);    
        }
    }
}