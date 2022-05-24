using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] float speedAmount = 5f;
    [SerializeField] float rotationSpeed = 720f;
    [SerializeField] Vector2 leftJoystickInput;
    [SerializeField] Vector2 rightJoystickInput;
    float inputMagnitude;

    [SerializeField] FixedJoystick leftJoystick;
    [SerializeField] FixedJoystick rightJoystick;

    void Start()
    {
        leftJoystickInput = new Vector2();
    }


    void Update()
    {
        SetInputValues();
        SetRotation();
        Move();
    }
    void SetInputValues()
    {
        leftJoystickInput.x = leftJoystick.Horizontal;
        leftJoystickInput.y = leftJoystick.Vertical;
        inputMagnitude = Mathf.Clamp01(leftJoystickInput.magnitude);
        leftJoystickInput.Normalize();


        rightJoystickInput.x = rightJoystick.Horizontal;
        rightJoystickInput.y = rightJoystick.Vertical;

        rightJoystickInput.Normalize();

    }
    void SetRotation()
    {

        if (rightJoystickInput.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, rightJoystickInput);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else if (leftJoystickInput.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, leftJoystickInput);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }
    void Move()
    {
        transform.Translate(leftJoystickInput * speedAmount * inputMagnitude * Time.deltaTime, Space.World);
    }


}
