using UnityEngine;
using System.Collections;

public class GroundMoverForward : MonoBehaviour {

    float speed = -0.1f;

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

    }
}
