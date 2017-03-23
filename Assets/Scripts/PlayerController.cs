using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    string teamTag;
    Vector3 movement;

	void Start () {
        teamTag = gameObject.tag;
        movement = Vector3.zero;
	}
	
    void FixedUpdate () {
        Move();
        Rotate();
    }

    void Move () {
        movement = new Vector3(speed * Input.GetAxisRaw(teamTag + "Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxisRaw(teamTag + "Vertical") * Time.deltaTime);
        transform.Translate(movement, Space.World);

        /*
         if (Input.GetAxisRaw(teamTag + "Horizontal")>0) {
             transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
         }
         if (Input.GetAxisRaw(teamTag + "Horizontal") < 0) {
             transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.World);
         }

         if (Input.GetAxisRaw(teamTag + "Vertical") > 0) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetAxisRaw(teamTag + "Vertical") < 0) {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World);
        }*/
    }

    void Rotate () {
        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(movement.normalized);
        }
    }

    void Update () {
	    
	}
}
