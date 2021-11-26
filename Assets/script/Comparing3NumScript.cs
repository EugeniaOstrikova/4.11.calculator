using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comparing3NumScript : MonoBehaviour
{
    [SerializeField] private GameObject comparingResultText;
    [SerializeField] private GameObject firstNumInput;
    [SerializeField] private GameObject secondNumInput;
    [SerializeField] private GameObject thirdNumInput;
    [SerializeField] private GameObject resetBtn;
    [SerializeField] private GameObject errorMessage;

    private string comparingResult;
    private int[] myInts = new int[3];

    void Start()
    {
        comparingResult = "";
        comparingResultText.GetComponent<Text>().text = "";
    }

    public void Compare()
    {
        string firstNumText = firstNumInput.GetComponent<InputField>().text;
        string secondNumText = secondNumInput.GetComponent<InputField>().text;
        string thirdNumText = thirdNumInput.GetComponent<InputField>().text;

        if ((firstNumText != "" && secondNumText != "") && thirdNumText != "")
        {
            int firstNumInt = System.Convert.ToInt32(firstNumText);
            int secondNumInt = System.Convert.ToInt32(secondNumText);
            int thirdNumInt = System.Convert.ToInt32(thirdNumText);

            myInts[0] = firstNumInt;
            myInts[1] = secondNumInt;
            myInts[2] = thirdNumInt;

            System.Array.Sort(myInts);

            if (myInts[0] == myInts[2] )
            {
                comparingResult = "The numbers are equal";
            }
            else if (myInts[2] == myInts[1])
            {
                comparingResult = "The largest number: " + myInts[2].ToString();
            }
            else
            {
                comparingResult = "The largest number: " + myInts[2].ToString() + ", " + myInts[1].ToString();
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
