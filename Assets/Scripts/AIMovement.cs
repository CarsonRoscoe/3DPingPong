using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class AIMovement : MonoBehaviour {
    public Transform Ball;
    public float Speed = .1f;
    private GameDataManager gameData;

    void Start() {
        gameData = GameDataManager.Instance;
    }

    // Update is called once per frame
    void Update() {
        if ( (transform.position.x < 0 && Ball.transform.position.x < 0) ||
             (transform.position.x > 0 && Ball.transform.position.x > 0) ) {
            var differenceInY = Ball.transform.position.y - transform.position.y;
            var differenceInZ = Ball.transform.position.z - transform.position.z;

            float yAmountMoved = differenceInY > 0 ? Mathf.Min( Speed, differenceInY ) : Mathf.Max( -Speed, differenceInY );
            float zAmountMoved = differenceInZ > 0 ? Mathf.Min( Speed, differenceInZ ) : Mathf.Max( -Speed, differenceInZ );

            var newY = transform.position.y + yAmountMoved;
            newY = Mathf.Min( newY, gameData.MaximumCourtY );
            newY = Mathf.Max( newY, gameData.MinimumCourtY );

            var newZ = transform.position.z + zAmountMoved;
            newZ = Mathf.Min( newZ, gameData.MaximumCourtZ );
            newZ = Mathf.Max( newZ, gameData.MinimumCourtZ );

            var newPosition = new Vector3( transform.position.x, newY, newZ );
            transform.position = newPosition;
        }
    }
}
