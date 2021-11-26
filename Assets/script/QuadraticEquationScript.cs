using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuadraticEquationScript : MonoBehaviour
{
    [SerializeField] private GameObject comparingResultText;
    [SerializeField] private GameObject firstNumInput;
    [SerializeField] private GameObject secondNumInput;
    [SerializeField] private GameObject thirdNumInput;
    [SerializeField] private GameObject resetBtn;
    [SerializeField] private GameObject errorMessage;

    private string comparingResult;

    void Start()
    {
        comparingResult = "";
        comparingResultText.GetComponent<Text>().text = "";
    }

    public void Deside()
    {
        string firstNumText = firstNumInput.GetComponent<InputField>().text;
        string secondNumText = secondNumInput.GetComponent<InputField>().text;
        string thirdNumText = thirdNumInput.GetComponent<InputField>().text;

        if ((firstNumText != "" && secondNumText != "") && thirdNumText != "")
        {
            double a = System.Convert.ToDouble(firstNumText);
            double b = System.Convert.ToDouble(secondNumText);
            double c = System.Convert.ToDouble(thirdNumText);

            double x1, x2;
            
            var discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                comparingResult = "Quadratic equation has no roots";
            }
            else
            {
                if (discriminant == 0)
                {
                    x1 = -b / (2 * a);
                    x2 = x1;
                }
                else
                {
                    x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                }
                comparingResult = ($"D = {discriminant}; x1 = {x1}; x2 = {x2}");
            }

            comparingResultText.GetComponent<Text>().text = comparingResult;
            errorMessage.SetActive(false);

            if (!resetBtn.activeSelf)
            {
                resetBtn.SetActive(true);
            }
        }
        else
        {
            errorMessage.GetComponent<Text>().text = "Please enter 3 numbers";
            errorMessage.SetActive(true);
        }
        
    }

    public void ResetData()
    {
        resetBtn.SetActive(false);
        comparingResult = "";
        comparingResultText.GetComponent<Text>().text = "";
        firstNumInput.GetComponent<InputField>().text = "";
        secondNumInput.GetComponent<InputField>().text = "";
        thirdNumInput.GetComponent<InputField>().text = "";
    }

}
