using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour{
    public float speed = 1f;
    Transform target;
    Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 pos = transform.position;

            Vector2 targetpos = target.position;

            //Vector3 mousePos = Input.mousePosition;
            //Vector3 worldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(mousePos);

            //targetpos = new Vector3((targetpos.x + mousePos.x)/2, (targetpos.y + mousePos.y)/2);

            Vector3 slerped = Vector3.Slerp(pos, targetpos, Time.deltaTime * speed);

            slerped.z = transform.position.z;

            transform.position = slerped;
        }
    }
}
