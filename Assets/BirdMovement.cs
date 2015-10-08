using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity   = Vector3.zero;
    float flapSpeed    = 20f;
    float forwardSpeed = 1f;
    bool didFlap = false;
    bool dead   = false;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = transform.GetComponentInChildren<Animator>();

        if(animator == null) {
            Debug.LogError("Didn't find animator!");
        }
	}

    // Do Graphic & Input updates here
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
            didFlap = true;
        }
    }

    // Do Physics engine updates here
    void FixedUpdate() {
        if (dead)
            return;

        GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);

        if (didFlap) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
            animator.SetTrigger("DoFlap");
            didFlap = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else {
            float angle = Mathf.Lerp(0, -45, (-GetComponent<Rigidbody2D>().velocity.y / 2f) );
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        animator.SetTrigger("Death");
        dead = true;
    }
}
