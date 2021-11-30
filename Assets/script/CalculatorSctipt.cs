using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorSctipt : MonoBehaviour
{
    [SerializeField] private OperationTypes currentOperation;
    [SerializeField] private Text operationText;
    [SerializeField] private InputField firstNumInput;
    [SerializeField] private InputField secondNumInput;
    [SerializeField] private InputField resultInput;
    [SerializeField] private GameObject resetBtn;
    [SerializeField] private GameObject errorMessage;

    private string currentOperationText;
    private string resultText;

    void Start()
    {
        currentOperationText = "";
        resultText = "";
        operationText.text = "";
    }

    public void SelectOperation(GameObject operationBtn)
    {
        currentOperation = operationBtn.GetComponent<OperationsScript>().operationType;

        switch (currentOperation)
        {
            case OperationTypes.Addition:
                currentOperationText = "+";
                break;
            case OperationTypes.Subtraction:
                currentOperationText = "-";
                break;
            case OperationTypes.Multiplication:
                currentOperationText = "*";
                break;
            case OperationTypes.Division:
                currentOperationText = "/";
                break;
            default:
                currentOperationText = "";
                break;
        }

        operationText.text = currentOperationText;
    }

    public void Calculate()
    {
        string firstNumText = firstNumInput.text;
        string secondNumText = secondNumInput.text;

        if ((firstNumText != "" && secondNumText != "") && currentOperation != OperationTypes.None)
        {

            int firstNumInt = System.Convert.ToInt32(firstNumText);
            int secondNumInt = System.Convert.ToInt32(secondNumText);

            int result;

            switch (currentOperation)
            {
                case OperationTypes.Addition:
                    result = firstNumInt + secondNumInt;
                    break;
                case OperationTypes.Subtraction:
                    result = firstNumInt - secondNumInt;
                    break;
                case OperationTypes.Multiplication:
                    result = firstNumInt * secondNumInt;
                    break;
                case OperationTypes.Division:
                    result = firstNumInt / secondNumInt;
                    break;
                default:
                    result = 0;
                    break;
            }

            resultText = result.ToString();
            resultInput.text = resultText;
            errorMessage.SetActive(false);

            if (!resetBtn.activeSelf)
            {
                resetBtn.SetActive(true);
            }
        }
        else
        {
            errorMessage.GetComponent<Text>().text = "Please enter 2 numbers and select an operation";
            errorMessage.SetActive(true);
        }
    }

    public void ResetData()
    {
        resetBtn.SetActive(false);
        currentOperation = OperationTypes.None;
        currentOperationText = "";
        resultText = "";
        operationText.text = "";
        firstNumInput.text = "";
        secondNumInput.text = "";
        resultInput.text = "";
    }
}
