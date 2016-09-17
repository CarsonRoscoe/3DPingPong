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
    }
}
