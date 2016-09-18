using UnityEngine;
using System.Collections;

namespace Assets.Scripts {
    public class MousePlayerMovement : BaseMovement {
        // Update is called once per frame
        void Update() {
            var gameData = GameDataManager.Instance;
            var widthPercent = Input.mousePosition.x / Screen.width;
            var heightPerecent = Input.mousePosition.y / Screen.height;

            var newZPosition = gameData.CourtWidth * widthPercent + gameData.MinimumCourtZ;
            var newYPosition = gameData.CourtHeight * heightPerecent + gameData.MinimumCourtY;

            transform.position = new Vector3( transform.position.x, newYPosition, newZPosition );
        }
    }
}

