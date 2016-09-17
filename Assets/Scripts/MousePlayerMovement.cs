using UnityEngine;
using System.Collections;

public class MousePlayerMovement : BasePaddleMovement {
    // Update is called once per frame
    void Update() {
        var widthPercent = Input.mousePosition.x / Screen.width;
        var heightPerecent = Input.mousePosition.y / Screen.height;

        var newZPosition = width * widthPercent + minWidth;
        var newYPosition = height * heightPerecent + minHeight;

        transform.position = new Vector3( transform.position.x, newYPosition, newZPosition );
    }
}
