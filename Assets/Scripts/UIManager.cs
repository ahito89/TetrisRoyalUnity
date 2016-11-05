using UnityEngine;

public class UIManager : MonoBehaviour {	
	private string _username;
	private SignalRUnityController _signalr;

	// Use this for initialization
	void Start () {
		_signalr = GameObject.Find("SignalRObject").GetComponent<SignalRUnityController>();
		_username = "";
	}
	
	public void Text_Changed (string newText) {
		_username = newText;		
	}

	public void LoginButton() {
		if (!string.IsNullOrEmpty(_username))
			_signalr.Login(_username);
	}
}
