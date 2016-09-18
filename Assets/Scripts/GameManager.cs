using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance;

        public Transform PlayerOne;
        public Transform PlayerTwo;
        public Transform Ball;

        void Awake() {
            if ( Instance == null ) {
                Instance = this;
            }
            else {
                Destroy( gameObject );
            }
        }

        void Start() {
            if (Application.platform == RuntimePlatform.Android) {
                GameDataManager.Instance.PlayerOneMovementType = MovementType.Mouse;
            }
            StartGame();
        }

        public void ResetScores() {
            GameDataManager.Instance.PlayerOneScore = 0;
            GameDataManager.Instance.PlayerTwoScore = 0;
            HUDManager.Instance.UpdateScores();
        }

        public void PlayerScore(int player) {
            var gameData = GameDataManager.Instance;
            switch ( player ) {
                case 1:
                    gameData.PlayerOneScore++;
                    if ( gameData.PlayerOneScore == gameData.MaxScore ) {
                        EndGame( player );
                    }
                    break;
                case 2:
                    gameData.PlayerTwoScore++;
                    if ( gameData.PlayerTwoScore == gameData.MaxScore ) {
                        EndGame( player );
                    }
                    break;
                default:
                    break;
            }
            HUDManager.Instance.UpdateScores();
        }

        public void TogglePauseGame() {
            HUDManager.Instance.ToggleInGameMenu();
        }

        public void StartGame() {
            AddController( PlayerOne.gameObject, GameDataManager.Instance.PlayerOneMovementType );
            AddController( PlayerTwo.gameObject, GameDataManager.Instance.PlayerTwoMovementType );
            GameDataManager.Instance.GameInProgress = true;
            HUDManager.Instance.StartGame();
        }

        public void EndGame(int winningPlayer) {
            ResetScores();
            GameDataManager.Instance.GameInProgress = false;
            HUDManager.Instance.EndGame( winningPlayer );
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

        private void AddController(GameObject player, MovementType movementType) {
            switch ( movementType ) {
                case MovementType.Controller:
                    break;
                case MovementType.Keyboard:
                    player.AddComponent( typeof( KeyboardPlayerMovement ) );
                    break;
                case MovementType.Mouse:
                    player.AddComponent( typeof( MousePlayerMovement ) );
                    break;
                case MovementType.AI:
                    var AI = player.AddComponent( typeof( AIMovement ) ) as AIMovement;
                    AI.Ball = Ball;
                    break;
            }
        }
    }
}
