using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comparing2NumScript : MonoBehaviour
{
    [SerializeField] private Text comparingResultText;
    [SerializeField] private InputField firstNumInput;
    [SerializeField] private InputField secondNumInput;
    [SerializeField] private GameObject resetBtn;
    [SerializeField] private GameObject errorMessage;

    private string comparingResult;

    void Start()
    {
        comparingResult = "";
        comparingResultText.text = "";
    }

    public void Compare()
    {
        string firstNumText = firstNumInput.text;
        string secondNumText = secondNumInput.text;

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

            comparingResultText.text = comparingResult;
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
        comparingResultText.text = "";
        firstNumInput.text = "";
        secondNumInput.text = "";
    }

}
