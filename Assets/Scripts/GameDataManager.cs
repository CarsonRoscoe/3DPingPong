using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public enum MovementType { Keyboard, Mouse, Controller }

    public class GameDataManager : MonoBehaviour {
        public static GameDataManager Instance;

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
    }
}
