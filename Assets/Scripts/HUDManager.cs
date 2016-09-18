using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class HUDManager : MonoBehaviour {
        public static HUDManager Instance;

        public GameObject PlayerOneScore;
        public GameObject PlayerTwoScore;
        private Text PlayerOneScoreText;
        private Text PlayerTwoScoreText;

        void Awake() {
            if ( Instance == null ) {
                Instance = this;
            }
            else {
                Destroy( gameObject );
            }
        }

        void Start() {
            PlayerOneScoreText = PlayerOneScore.GetComponent<Text>();
            PlayerTwoScoreText = PlayerTwoScore.GetComponent<Text>();
        }

        public void UpdateScores() {
            PlayerOneScoreText.text = GameDataManager.Instance.PlayerOneScore.ToString();
            PlayerTwoScoreText.text = GameDataManager.Instance.PlayerTwoScore.ToString();
        }
    }
}
