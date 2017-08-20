using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible of the needle in the ammeter or the voltmeter. The script is attached to the corresponding needle. When the targetAngle value is modified, the needle will head to destination and will approach 
//asymptotically. 
public class InstrumentIndicator : MonoBehaviour {

	public float targetAngle = 0; 
	public float needleViscosity = 3;


	private float currentAngle; 


	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {
		
		currentAngle = Mathf.Lerp(currentAngle,targetAngle,Time.deltaTime*needleViscosity);
		currentAngle = Mathf.Clamp (currentAngle, -50f, 5f);
		gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, currentAngle));
	}
}
