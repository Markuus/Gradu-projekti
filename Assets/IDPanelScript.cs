using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IDPanelScript : MonoBehaviour
{

    public TMP_InputField input;
    public GameObject idPanel;
    public GameObject showIdNumber;
    public TMP_Text idText;
    private IDSaver idSaverScript;
    public string idNumber;

    private void Start()
    {
        showIdNumber.SetActive(false);
        //idSaverScript = idSaver.GetComponent<IDSaver>();
        idSaverScript = FindObjectOfType<IDSaver>();
    }

    public void setIdNumber()
    {
        idNumber = input.text;
        if(idNumber != "")
        {
            idPanel.SetActive(false);
            showIdNumber.SetActive(true);
            idText.text = idNumber;
            idSaverScript.setId(idNumber);
        }
    }

    public void openIdPanel()
    {
        idPanel.SetActive(true);
    }

    public string getIdNumber()
    {
        return idNumber;
    }
}
