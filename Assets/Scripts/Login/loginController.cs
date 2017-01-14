using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loginController : MonoBehaviour {

    [SerializeField]
    private GameObject loginDisplay;
    [SerializeField]
    private GameObject createAccountDisplay;
    [SerializeField]
    private GameObject recoverPasswordDisplay;
    

	void Start () {
        onLogin();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onCreateAccount()
    {
        loginDisplay.SetActive(false);
        recoverPasswordDisplay.SetActive(false);
        createAccountDisplay.SetActive(true);
    }
    public void onRecoverPassword()
    {
        loginDisplay.SetActive(false);
        recoverPasswordDisplay.SetActive(true);
        createAccountDisplay.SetActive(false);
    }
    public void onLogin()
    {
        loginDisplay.SetActive(true);
        recoverPasswordDisplay.SetActive(false);
        createAccountDisplay.SetActive(false);
    }

}
