using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts {
    public class Transparent : MonoBehaviour {

        void Update() {
            foreach ( var renderer in gameObject.GetComponentsInChildren<Renderer>() ) {
                var color = renderer.material.color;
                color.a = .25f;
                renderer.material.color = color;
                //renderer.enabled = false;
            }
        }
    }
}
