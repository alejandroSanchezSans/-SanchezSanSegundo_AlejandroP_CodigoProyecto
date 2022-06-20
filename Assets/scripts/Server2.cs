using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Server2 : MonoBehaviour
{
	[SerializeField] GameObject welcomePanel;
	[SerializeField] Text user;
	[Space]
	[SerializeField] InputField username;
	[SerializeField] InputField password;

	[SerializeField] Text errorMessages;
	[SerializeField] GameObject progressCircle;


	[SerializeField] Button loginButton;

	
	[SerializeField] string url;
	bool welcomeIsActive = false;

	WWWForm form;

	public void OnLoginButtonClicked ()
	{
		if (username.text != "" || password.text != "") {
			loginButton.interactable = false;
			progressCircle.SetActive(true);
			StartCoroutine(Login()); }
		if(username.text == "" || password.text == "") {
			errorMessages.text = "Error. Revise los campos.";
			//error

		}
	}

	IEnumerator Login ()
	{
		form = new WWWForm ();

		form.AddField ("username", username.text);
		form.AddField ("password", password.text);

		WWW w = new WWW (url, form);
		yield return w;

		if (w.error != null) {
			errorMessages.text = "404 not found!";
			Debug.Log("<color=red>"+w.text+"</color>");//error
		} else {
			if (w.isDone) {
				if (w.text.Contains ("error")) {
					errorMessages.text = "invalid username or password!";
					Debug.Log("<color=red>"+w.text+"</color>");//error
				} if(w.text.Contains("success")) {
					//open welcom panel
					welcomePanel.SetActive (true);
					welcomeIsActive = true;
					user.text = username.text;
					Debug.Log("<color=green>"+w.text+"</color>");//user exist
				}

			}


			if (!welcomeIsActive) {
				errorMessages.text="Revise los campos.";
			
			}
		}

		loginButton.interactable = true;
		progressCircle.SetActive (false);

		w.Dispose ();
	}
}
