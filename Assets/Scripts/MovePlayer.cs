using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 4.0f;
    
    void Update()
    {
        float dx = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float dy = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position = transform.position + new Vector3(dx, dy);
    }
}
