using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class HUDManager : MonoBehaviour {
        public static HUDManager Instance;

        public GameObject PlayerOneScore;
        public GameObject PlayerTwoScore;
        private TextMesh PlayerOneScoreText;
        private TextMesh PlayerTwoScoreText;

        void Awake() {
            if ( Instance == null ) {
                Instance = this;
            }
            else {
                Destroy( gameObject );
            }
        }

        void Start() {
            PlayerOneScoreText = PlayerOneScore.GetComponent<TextMesh>();
            PlayerTwoScoreText = PlayerTwoScore.GetComponent<TextMesh>();
        }

        public void UpdateScores() {
            PlayerOneScoreText.text = GameDataManager.Instance.PlayerOneScore.ToString();
            PlayerTwoScoreText.text = GameDataManager.Instance.PlayerTwoScore.ToString();
        }
    }
}
