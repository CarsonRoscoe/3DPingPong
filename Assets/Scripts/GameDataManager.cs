using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public enum MovementType { Keyboard, Mouse, Controller }

    public class GameDataManager : MonoBehaviour {
        public static GameDataManager Instance;

        public Transform LeftWall;
        public Transform RightWall;
        public Transform Ceiling;
        public Transform Floor;

        public float MinimumCourtZ;
        public float MaximumCourtZ;
        public float MinimumCourtY;
        public float MaximumCourtY;
        public float CourtWidth;
        public float CourtHeight;

        public MovementType MovementType { get; set; }

        private int _playerOneScore;
        public int PlayerOneScore {
            get {
                return _playerOneScore;
            }
            set {
                if ( value >= 0 ) {
                    _playerOneScore = value;
                }
            }
        }

        private int _playerTwoScore;
        public int PlayerTwoScore {
            get {
                return _playerTwoScore;
            }
            set {
                if (value >= 0) {
                    _playerTwoScore = value;
                }
            }
        }


        void Awake() {
            if ( Instance == null ) {
                Instance = this;
            }
            else {
                Destroy( gameObject );
            }
        }

        // Use this for initialization
        void Start() {
            MinimumCourtZ = LeftWall.position.z + ((transform.lossyScale.z) / 2 + .5f);
            MaximumCourtZ = RightWall.position.z - ((transform.lossyScale.z) / 2 + .5f);
            MinimumCourtY = Floor.position.y + ((transform.lossyScale.y) / 2 + .5f);
            MaximumCourtY = Ceiling.position.y - ((transform.lossyScale.y) / 2 + .5f);
            CourtWidth = MaximumCourtZ - MinimumCourtZ;
            CourtHeight = MaximumCourtY - MinimumCourtY;
        }
    }
}
