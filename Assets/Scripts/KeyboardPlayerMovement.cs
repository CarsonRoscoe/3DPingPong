using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class KeyboardPlayerMovement : MonoBehaviour {
        public float movementSpeed = .3f;

        // Update is called once per frame
        void Update() {
            var gameData = GameDataManager.Instance;
            var newYPosition = transform.position.y + Input.GetAxis( "Vertical" ) * movementSpeed;
            newYPosition = Mathf.Min( newYPosition, gameData.MaximumCourtY );
            newYPosition = Mathf.Max( newYPosition, gameData.MinimumCourtY );

            var newZPosition = transform.position.z + Input.GetAxis( "Horizontal" ) * movementSpeed;
            newZPosition = Mathf.Min( newZPosition, gameData.MaximumCourtZ );
            newZPosition = Mathf.Max( newZPosition, gameData.MinimumCourtZ );

            transform.position = new Vector3( transform.position.x, newYPosition, newZPosition );
        }
    }
}
