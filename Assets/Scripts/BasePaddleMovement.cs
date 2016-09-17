using UnityEngine;
using System.Collections;

public class BasePaddleMovement : MonoBehaviour {
    public Transform LeftWall;
    public Transform RightWall;
    public Transform Ceiling;
    public Transform Floor;
    protected float minWidth;
    protected float maxWidth;
    protected float minHeight;
    protected float maxHeight;
    protected float width;
    protected float height;

    // Use this for initialization
    void Start() {
        minWidth = LeftWall.position.z + ((transform.lossyScale.z) / 2 + .5f);
        maxWidth = RightWall.position.z - ((transform.lossyScale.z) / 2 + .5f);
        minHeight = Floor.position.y + ((transform.lossyScale.y) / 2 + .5f);
        maxHeight = Ceiling.position.y - ((transform.lossyScale.y) / 2 + .5f);
        width = maxWidth - minWidth;
        height = maxHeight - minHeight;
    }
}
