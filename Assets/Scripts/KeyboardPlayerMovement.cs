using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class KeyboardPlayerMovement : BasePaddleMovement {
        public float movementSpeed = .3f;

        // Update is called once per frame
        void Update() {
            var newYPosition = transform.position.y + Input.GetAxis( "Vertical" ) * movementSpeed;
            newYPosition = Mathf.Min( newYPosition, maxHeight );
            newYPosition = Mathf.Max( newYPosition, minHeight );

            var newZPosition = transform.position.z + Input.GetAxis( "Horizontal" ) * movementSpeed;
            newZPosition = Mathf.Min( newZPosition, maxWidth );
            newZPosition = Mathf.Max( newZPosition, minWidth );

            transform.position = new Vector3( transform.position.x, newYPosition, newZPosition );
        }
    }
}
