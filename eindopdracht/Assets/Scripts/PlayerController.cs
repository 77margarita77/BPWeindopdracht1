using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject cam;
    private float moveSpeed;
    //private float oldMoveSpeed;
    public float mouseSensitivityX, mouseSensitivityY;
    private Rigidbody rigidBody;
    private float verticalAxis;
    private float horizontalAxis;
    private float angleX, angleY;
    private float mouseX, mouseY;
    private bool jump;
    public float jumpForce = 200;
    public float rayCastRange = 0.25f;
    public float runSpeed = 12f;
    public float normalSpeed = 3f;

    //public float runSpeed;
    //private bool run;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Cursor.visible = false;
        //oldMoveSpeed = moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        //Get input from WASD
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        //Get Input from the mouse movement
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //Input for Jump
        jump = Input.GetKeyDown(KeyCode.Space);
        Debug.DrawLine(transform.position, transform.position + -transform.up * rayCastRange);

        if (jump)
        {
            DoJump();
        }
        
        //Look Up and Down
        angleY += mouseY * mouseSensitivityY;
        angleY = Mathf.Clamp(angleY, -89f, 89f);
        cam.transform.localRotation = Quaternion.Euler(-angleY, 0, 0);

        //Look Right and Left
        angleX += mouseX * mouseSensitivityX;
        transform.rotation = Quaternion.Euler(0, angleX, 0);

        if (Input.GetKey (KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = normalSpeed;
        }
    }

    private void FixedUpdate()
    {

        Vector3 forwardMovement = transform.forward * verticalAxis;
        Vector3 sideMovement = transform.right * horizontalAxis;
        rigidBody.MovePosition(rigidBody.position + (forwardMovement + sideMovement).normalized * moveSpeed * Time.deltaTime);
        
        
    }

    private void DoJump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.up * 0.1f, -transform.up, out hit, rayCastRange))
        {
            rigidBody.AddForce(transform.up * jumpForce);
            Debug.Log("spring");
        }
    }


}