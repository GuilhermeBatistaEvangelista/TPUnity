using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float sensitivity = 100f;

    public Transform player;

    float Rotation=0f;
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*sensitivity*Time.deltaTime;
        
        //Rotação do player em X
        player.Rotate(Vector3.up* mouseX);

        //Rotação da camera em Y
        Rotation -= mouseY;
        Rotation = Mathf.Clamp(Rotation,-90f,90f);
        transform.localRotation = Quaternion.Euler(Rotation,0f,0f);
    }
}
