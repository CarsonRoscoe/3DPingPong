using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {
    private Rigidbody rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        var xForceSpeed = 500;
        var yzForceSpeed = 200;
        var xForce = Random.value >= .5 ? xForceSpeed : -xForceSpeed;
        var yForce = Random.value * yzForceSpeed - yzForceSpeed / 2;
        var zForce = Random.value * yzForceSpeed - yzForceSpeed / 2;
        rigidBody.AddForce( xForce, yForce, zForce );
    }

    void OnCollisionEnter( Collision collision ) {
        var collider = collision.collider;
        if ( collider.tag == "Paddle" ) {
            var paddlePosition = collision.collider.transform.position;
            var yDifference = transform.position.y - paddlePosition.y;
            var zDifference = transform.position.z - paddlePosition.z;
            var colliderScale = collider.transform.lossyScale;
            var forceSpeed = 300;

            rigidBody.AddForce( 0, yDifference * forceSpeed / colliderScale.y, zDifference * forceSpeed / colliderScale.z );
        }
    }
}
