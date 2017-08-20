using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ce script est utilisé par les 
public class ScaleSpriteScript : MonoBehaviour {
	public InstrumentController instrument; 
	public int scaleID = 1; 

	void OnMouseDown() {
		instrument.setScale(scaleID); 
		Debug.Log ("Scale changed");
	}
}
