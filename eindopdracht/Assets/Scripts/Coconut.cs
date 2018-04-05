using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    public Vector3 startPos;
    public int rStart;
    public int rEnd;
    public int result;
    private Component hinge;
    private Component rb;

    // Use this for initialization
    void Start ()
    {
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        result = Random.Range(rStart, rEnd);
        hinge = GetComponent<HingeJoint>();
        if(result == 29)
        {
            Destroy(hinge);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "statue")
        {
            transform.position = startPos;
            gameObject.AddComponent<HingeJoint>();
        }
    }
}
