using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public Transform target1;
    public Transform target2;


    private Vector3 offset = new Vector3(0, 0, 5);

    void Start()
    {
        offset = transform.position;
        transform.LookAt(target1);
        transform.LookAt(target2);
        //transform.position += offset;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(target1);
        //transform.LookAt(target2);
       // transform.position += offset;
    }
}
