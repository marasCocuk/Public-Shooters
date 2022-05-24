using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] float speedAmount = 5f;
    [SerializeField] float rotationSpeed = 720f;
    [SerializeField] Vector2 moveVector;
    float inputMagnitude;

    void Start()
    {
        moveVector = new Vector2();
    }


    void Update()
    {
        SetInputValues();
        SetRotation();
        Move();
    }
    void SetInputValues()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        inputMagnitude = Mathf.Clamp01(moveVector.magnitude);
        moveVector.Normalize();
    }
    void SetRotation()
    {
        if (moveVector.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }
    void Move()
    {
        transform.Translate(moveVector * speedAmount * inputMagnitude * Time.deltaTime, Space.World);
    }


}
