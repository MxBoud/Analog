using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour {
	public Toggle toggleVoltmeter; 
	public Toggle toggleAmmeter; 

	public Text userInputUnits; 

	public GameController gameController;
	public GameObject voltmeterObject; 
	public GameObject ammeterObject; 



	public void valueChanged(){
			if (toggleVoltmeter.isOn) {
				voltmeterObject.SetActive(true); 
				ammeterObject.SetActive(false); 
			userInputUnits.text = "V";
			gameController.instrumentSelector = 0;

		}
			else {
				voltmeterObject.SetActive(false); 
				ammeterObject.SetActive(true); 
				userInputUnits.text = "A";
				gameController.instrumentSelector = 1;
		}
	}

}
