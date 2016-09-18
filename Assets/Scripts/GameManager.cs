using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance;

        void Awake() {
            if ( Instance == null ) {
                Instance = this;
            }
            else {
                Destroy( gameObject );
            }
        }

        public void ResetScores() {
            GameDataManager.Instance.PlayerOneScore = 0;
            GameDataManager.Instance.PlayerTwoScore = 0;
            HUDManager.Instance.UpdateScores();
        }

        public void PlayerOneScore() {
            GameDataManager.Instance.PlayerOneScore++;
            HUDManager.Instance.UpdateScores();
        }

        public void PlayerTwoScore() {
            GameDataManager.Instance.PlayerTwoScore++;
            HUDManager.Instance.UpdateScores();
        }

        public void ResetCourt(GameObject ball) {
            if (ball != null ) {
                var ballBehaviour = ball.GetComponent<BallBehaviour>();
                var rigidBody = ball.GetComponent<Rigidbody>();

                if ( ballBehaviour != null && rigidBody != null) {
                    var gameData = GameDataManager.Instance;

                    var newBallZ = gameData.MinimumCourtZ + gameData.CourtWidth / 2f;
                    var newBallY = gameData.MinimumCourtY + gameData.CourtHeight / 2f;
                    var newBallX = 0f;

                    ball.transform.position = new Vector3( newBallX, newBallY, newBallZ );


                    var xForce = UnityEngine.Random.value >= .5 ? ballBehaviour.XForceSpeed : -ballBehaviour.XForceSpeed;
                    var yForce = UnityEngine.Random.value * ballBehaviour.YZForceSpeed - ballBehaviour.YZForceSpeed / 2;
                    var zForce = UnityEngine.Random.value * ballBehaviour.YZForceSpeed - ballBehaviour.YZForceSpeed / 2;

                    if ( rigidBody != null ) {
                        rigidBody.velocity = Vector3.zero;
                        rigidBody.AddForce( xForce, yForce, zForce );
                    }
                }
            }
        }
    }
}
