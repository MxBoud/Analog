using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurementParsor  {
	//The measurement parsor class use a more complexified parsor algorithm 
	//to apply the differents rules needed so that a measurement is correctly
	//written. In case of a mistake, the public string "outputMessage" gives instructions to correct the input. 
	public string measurement; 
	public string uncertainty; 

	public string outputMessage;

	public float mResult;
	public float uResult; 
	public int uSepPos;
    public int mSepPos;
    public int mCharBeforeEnd;
	public int uCharBeforeEnd;
    public bool parseSuccess = true; 

	public MeasurementParsor(string newMeasurement, string newUncertainty)
	{
		measurement = newMeasurement;
		uncertainty = newUncertainty;
		Parse();
	}

	public void Parse()
	{
		//Replace comma by points 
		measurement = measurement.Replace(',', '.');
		uncertainty = uncertainty.Replace(',', '.');

		// Initial parse 
		parseSuccess = float.TryParse(measurement, out mResult);

		if (!parseSuccess)
		{
			outputMessage = "Entrée invalide (mesure)";
			return;//need to put a message 
		}

		parseSuccess = float.TryParse(uncertainty, out uResult);

		if (!parseSuccess)
		{
			outputMessage = "Entrée invalide (Incertitude)";
			return;//need to put a message 
		}

		//Check for uncertainty convention

		//First: One significant digit for uncertainty
		int counter = 0;
		foreach (char c in uncertainty)
		{
			if (c != '0' && c != '.')
			{
				counter++;
			}
		}
		if (counter != 1)
		{
			outputMessage = "L'incertitude doit comporter un seul chiffre significatif";
            parseSuccess = false; 
			return;
		}
		if (uncertainty[uncertainty.Length - 1] == '0')
		{
			outputMessage = "L'incertitude doit comporter un seul chiffre significatif";
            parseSuccess = false;
			return;
		}

		//Second : Check that both number finish at the same decimal position
		if (measurement.IndexOf('.') ==-1 ^ uncertainty.IndexOf('.')==-1)
		{
			outputMessage = "Le dernier chiffre significatif de la mesure et de l'incertitude doivent se trouver à la même position décimale.";
            parseSuccess = false;
			return;
		}
		mCharBeforeEnd = measurement.Length - measurement.IndexOf('.') - 1;
		uCharBeforeEnd = uncertainty.Length - uncertainty.IndexOf('.') - 1;

		if (mCharBeforeEnd != uCharBeforeEnd)
		{
            if (measurement.IndexOf('.') != -1 && uncertainty.IndexOf('.') != -1)
            {
                parseSuccess = false;
                outputMessage = "Le dernier chiffre significatif de la mesure et de l'incertitude doivent se trouver à la même position décimale.";
                return;
            }

		}

		outputMessage = "Mesure adéquate";

	}

}
