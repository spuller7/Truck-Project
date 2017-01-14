using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class DisplayText : MonoBehaviour
{
    public RectTransform myPanel;
    public GameObject myTextPrefab;
    List<string> chatEvents;
    private float nextMessage;
    private int myNumber = 0;
    private GameObject newText;
    public GameObject ChatWindow;
    public GameObject ChatInput;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!ChatWindow.activeSelf)
            {
                ChatWindow.SetActive(true);
                ChatInput.GetComponent<InputField>().ActivateInputField();

            }
            else
            {
                if (ChatInput.GetComponent<InputField>().text.Equals(""))
                {
                    ChatWindow.SetActive(false);
                }
                else
                {
                    GameObject newText = (GameObject)Instantiate(myTextPrefab);
                    newText.transform.SetParent(myPanel);
                    newText.GetComponent<Text>().text = ChatInput.GetComponent<InputField>().text;
                    ChatInput.GetComponent<InputField>().text = "";
                    ChatInput.GetComponent<InputField>().ActivateInputField();
                    GameObject.Find("rect").GetComponent<ScrollRect>().verticalNormalizedPosition = 0;

                }
                
            }
        }
    }
}