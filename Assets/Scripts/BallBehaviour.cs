using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {
    public int MinimumSpeed = 20;
    public int XForceSpeed = 500;
    public int YZForceSpeed = 200;

    private Rigidbody rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        var xForce = Random.value >= .5 ? XForceSpeed : -XForceSpeed;
        var yForce = Random.value * YZForceSpeed - YZForceSpeed / 2;
        var zForce = Random.value * YZForceSpeed - YZForceSpeed / 2;
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

    void Update() {
        if (rigidBody.velocity.x > 0 && rigidBody.velocity.x < MinimumSpeed ) {
            rigidBody.AddForce( 5, 0, 0 );
        }
        else if ( rigidBody.velocity.x < 0 && rigidBody.velocity.x > -MinimumSpeed ) {
            rigidBody.AddForce( -5, 0, 0 );
        }
    }
}
