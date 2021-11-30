using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationsScript : MonoBehaviour
{
    [SerializeField] public OperationTypes operationType;
    [SerializeField] private Text operationText;
    private string text;

    void Start()
    {
        switch (operationType) {
            case OperationTypes.Addition: 
                text = "+";
                break;
            case OperationTypes.Subtraction: 
                text = "-";
                break;
            case OperationTypes.Multiplication: 
                text = "*";
                break;
            case OperationTypes.Division: 
                text = "/";
                break;
            default: 
                text = "=";
                break;
        }
        
        operationText.text = text;
    }

}
