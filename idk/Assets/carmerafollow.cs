using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmerafollow : MonoBehaviour

{

    public Transform target;
    public float camera_speed;
    public float minX, maxX;
    public float minY, maxY;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (target != null)
        { Vector2 newCamPosition = Vector2.Lerp(transform.position, target.position, Time.deltaTime * camera_speed); 
        float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
        float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
        transform.position = new Vector3(ClampX, ClampY, -10f); }

    }

}