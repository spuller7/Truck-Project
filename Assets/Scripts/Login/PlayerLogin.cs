using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLogin : Photon.MonoBehaviour
{

    int totalPlayers = 0;   // sum of players in all listed rooms

    public string createAccountUrl = "http://127.0.0.1/CreateAccount.php";
    private string LoginUrl = "http://127.0.0.1/LoginAccount.php";

    public static string email;
    public static string password;
    public static string username;

    [Header("GUI Script")]
    [SerializeField]
    private loginController loginController;

    //All input field
    [Header("Login")]
    [SerializeField]
    private InputField l_Email;
    [SerializeField]
    private InputField l_Password;
    [SerializeField]
    private Button loginButton;

    [Header("Create Account")]
    [SerializeField]
    private InputField ca_Email;
    [SerializeField]
    private InputField ca_ConfirmEmail;
    [SerializeField]
    private InputField ca_Password;
    [SerializeField]
    private InputField ca_ConfirmPassword;
    [SerializeField]
    private InputField ca_Username;
    [SerializeField]
    private Button createAccountButton;

    [Header("Recover Password")]
    [SerializeField]
    private InputField rp_Email;
    [SerializeField]
    private Button recoverPasswordButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void onCreateAccount()
    {
        if(ca_Email.text == ca_ConfirmEmail.text && ca_Email.text != null && ca_Password.text == ca_ConfirmPassword.text && ca_Password != null && ca_Username != null)
        {
            email = ca_Email.text;
            password = ca_Password.text;
            username = ca_Username.text;
            StartCoroutine("CreateAccount");
        }
        else
        {
            if(ca_Email.text != ca_ConfirmEmail.text)
            {
                Debug.Log("Emails do not match");
            }
            if(ca_Password.text == ca_ConfirmPassword.text)
            {
                Debug.Log("Passwords do not match");
            }
            if (ca_Password == null || ca_Email == null || ca_Username == null) 
            {
                Debug.Log("You must fill in every field!");
            }
        }
    }

    public void onLogin()
    {
        if(l_Email != null && l_Password != null)
        {
            StartCoroutine("LoginAccount");
        }
        else
        {
            Debug.Log("You must fill in every field!");
        }
    }
    public void onRecoverPassword()
    {

    }
   
    IEnumerator CreateAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("Email", email);
        form.AddField("Password", password);
        form.AddField("Username", username);
        WWW createAccountWWW = new WWW(createAccountUrl, form);
        yield return createAccountWWW;
        if (createAccountWWW.error != null)
        {
            Debug.LogError("Cannot Create Account");
        }
        else
        {
            string createAccountReturn = createAccountWWW.text;
            if (createAccountReturn == "Success")
            {
                Debug.Log("Account has been created");
                loginController.onLogin();
            }
            else if(createAccountReturn == "AlreadyUsed")
            {
                Debug.Log("Already Used");
            }
            else if (createAccountReturn == "Empty")
            {
                Debug.Log("emp");
            }else
            {
                Debug.Log("working?");
            }
        }
    }
    IEnumerator LoginAccount()
    {
        WWWForm Form = new WWWForm();
        Form.AddField("Email", l_Email.text);
        Form.AddField("Password", l_Password.text);
        WWW LoginWWW = new WWW(LoginUrl, Form);
        yield return LoginWWW;
        if (LoginWWW.error != null)
        {
            Debug.LogError("Cannot connect to login");
        }
        else
        {
            string logText = LoginWWW.text;
            Debug.Log(logText);
            string[] logTextSplit = logText.Split(':');
            if (logTextSplit[0] == "Success")
            {
                Debug.Log("Login Succesful");
                Debug.Log("Welcome " + logTextSplit[1]);
                //Save name
                PhotonNetwork.playerName = logTextSplit[1];
                Application.LoadLevel("Menu");
            }

        }

    }


}