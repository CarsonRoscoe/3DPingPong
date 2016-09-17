using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ColorObject : MonoBehaviour {
  public Color ObjectColor;

  private Color currentColor;
  private Material materialColored;

  void Update() {
    if ( ObjectColor != currentColor ) {
      //create a new material
      materialColored = new Material( Shader.Find( "Diffuse" ) );
      materialColored.color = currentColor = ObjectColor;
      this.GetComponent<Renderer>().material = materialColored;
    }
  }
}