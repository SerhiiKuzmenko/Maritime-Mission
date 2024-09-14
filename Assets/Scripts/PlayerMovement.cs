using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxMovementSpeed = 0.001f;
    [SerializeField] float maxAngle = 0.1f;
    [SerializeField] float maxSlowdown = 0.5f;
    float currentSlowdown = 1;

    void Start()
    {
        
    }

    

    void Update()
    {
        
        float currentSpeed = currentSlowdown * maxMovementSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(0, currentSpeed, 0);

        if (currentSlowdown < 1)
        {
            currentSlowdown += Time.deltaTime;
        }

        float verticalMultiplier = (Input.GetAxis("Vertical") == 0 ? 1 : Input.GetAxis("Vertical"));

        float currentAngel = verticalMultiplier * maxAngle * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Rotate(0, 0, -currentAngel);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        currentSlowdown = maxSlowdown;
    }

    
}
