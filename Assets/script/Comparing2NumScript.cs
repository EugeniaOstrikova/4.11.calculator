using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comparing2NumScript : MonoBehaviour
{
    [SerializeField] private GameObject comparingResultText;
    [SerializeField] private GameObject firstNumInput;
    [SerializeField] private GameObject secondNumInput;
    [SerializeField] private GameObject resetBtn;
    [SerializeField] private GameObject errorMessage;

    private string comparingResult;

    void Start()
    {
        comparingResult = "";
        comparingResultText.GetComponent<Text>().text = "";
    }

    public void Compare()
    {
        string firstNumText = firstNumInput.GetComponent<InputField>().text;
        string secondNumText = secondNumInput.GetComponent<InputField>().text;

        if (firstNumText != "" && secondNumText != "")
        {
            int firstNumInt = System.Convert.ToInt32(firstNumText);
            int secondNumInt = System.Convert.ToInt32(secondNumText);

            if (firstNumInt == secondNumInt)
            {
                comparingResult = "=";
            }
            else if (firstNumInt > secondNumInt)
            {
                comparingResult = ">";
            }
            else
            {
                comparingResult = "<";
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
            errorMessage.GetComponent<Text>().text = "Please enter 2 numbers";
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
    }

}
