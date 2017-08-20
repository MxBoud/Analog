using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentController : MonoBehaviour {

    //This class embed all shared characheristics of the ammeter and volmeter

	public int instrumentSelector = 0; // 0 = volmeter, 1= amperemeter 
	private InstrumentIndicator needle; //Needle of the analog display
	public int scaleID = 1; 
    private float scale;//Maximum value of the scale;

	public float inputToInstrument = 0; 

	private Color grey = new Color ((float)75 / 255, (float)75 / 255, (float)75 / 255);
	private Color yellow = new Color((float)219/255,(float)255/255,0);

	public SpriteRenderer[] scaleSprite = new SpriteRenderer[3]; 

    void Start() {
        needle = GetComponentInChildren<InstrumentIndicator>();
    }

	void UpdateVoltmeterView() {
		switch (scaleID) {
		case 1: 
			scale = 3; 
			break; 
		case 2: 
			scale = 15; 
			break; 
		case 3: 
			scale = 30; 
			break; 
		default: 
			scale = 3;
			break; 
		}

		needle.targetAngle = -44.8f*inputToInstrument/scale; 
	}
	void UpdateAmmeterView() {
		switch (scaleID) {
		case 1: 
			scale = 0.05f; 
			break; 
		case 2: 
			scale = 0.5f; 
			break; 
		case 3: 
			scale = 5; 
			break; 
		default: 
			scale = 0.05f;
			break; 
		}

		needle.targetAngle = -44.8f*inputToInstrument/scale; 
	}


	void Update () {
		if (instrumentSelector == 0) {//Volmeter) 
			UpdateVoltmeterView ();

		} else if (instrumentSelector == 1) { //Ammmeter 
			UpdateAmmeterView() ; 
		}


	}

	
	// Update is called once per frame


	public void setScale(int desiredScaleID)
	{
		scaleID = desiredScaleID;
		updateScaleColor (scaleID);

		Debug.Log (scale);
	}






	void updateScaleColor (int scaleID)
	{
		foreach(SpriteRenderer spriteObject in scaleSprite) {
			spriteObject.color = grey; 
			
		}
		scaleSprite [scaleID - 1].color = yellow; 
	}


}
