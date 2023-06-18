using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float movementSpeed = 7f;
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis ("Vertical")) * movementSpeed * Time.deltaTime);
    }
}
