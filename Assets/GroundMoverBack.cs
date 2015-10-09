using UnityEngine;
using System.Collections;

public class GroundMoverBack : MonoBehaviour {

    float speed = -0.7f;

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

    }
}
