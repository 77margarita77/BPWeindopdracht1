using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {
    GameObject mainCamera;
    bool carrying;
    public GameObject carriedObject;
    public float distance;
    public float smooth;
    public float force;
    public Transform cam;
    public Transform badonk;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        cam = GetComponent<Transform>();
        badonk = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
            //rotateObject();
        }
        else
        {
            pickup();
        }
    }

    void rotateObject()
    {
        carriedObject.transform.Rotate(5, 10, 15);
    }

    void carry(GameObject o)
    {
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        o.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        o.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        o.transform.rotation = Quaternion.identity;
    }

    void pickup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    //p.gameObject.rigidbody.isKinematic = true;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carrying = false;
        //carriedObject.gameObject.rigidbody.isKinematic = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        badonk = carriedObject.GetComponent<Transform>();
        badonk = cam.transform;
        carriedObject.GetComponent<Rigidbody>().AddForce(badonk.transform.forward * force);
        carriedObject = null;
    }
}