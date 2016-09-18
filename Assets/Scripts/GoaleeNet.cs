using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class GoaleeNet : MonoBehaviour {
        public int PlayerNumber = 1;

        void OnCollisionEnter( Collision collision ) {
            Debug.Log( "Hit" );
            var collider = collision.collider;
            if ( collider.tag == "Ball" ) {
                var ballObject = collider.gameObject;
                switch ( PlayerNumber ) {
                    case 1:
                        GameManager.Instance.PlayerTwoScore();
                        GameManager.Instance.ResetCourt( ballObject );
                        break;
                    case 2:
                        GameManager.Instance.PlayerOneScore();
                        GameManager.Instance.ResetCourt( ballObject );
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
