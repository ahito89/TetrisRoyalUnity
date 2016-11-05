using UnityEngine;
using System.Collections;
using SignalR.Client._20.Hubs;

public class SignalRUnityController : MonoBehaviour {

    public bool useSignalR = true;
    public string signalRUrl = "http://localhost:49167/game";

    private HubConnection _hubConnection = null;
    private IHubProxy _hubProxy;
    
	// Use this for initialization
	void Start () {
        if (useSignalR)
            StartSignalR();
	}

    void StartSignalR()
    {
        if (_hubConnection == null)
        {
            _hubConnection = new HubConnection(signalRUrl);
            _hubProxy = _hubConnection.CreateProxy("game");
            var _loginSub = _hubProxy.Subscribe("Login");            
            _loginSub.Data += data =>
            {
                Debug.Log("signalR login");
            };

            var _recGamesSub = _hubProxy.Subscribe("ReceiveGames");
            _recGamesSub.Data += data =>
            {
                Debug.Log("signalR received games");
            };

            var _addGameSub = _hubProxy.Subscribe("AddGame");
            _addGameSub.Data += data =>
            {
                Debug.Log("signalR add game");
            };

            var _loginFailedSub = _hubProxy.Subscribe("LoginFailed");
            _loginFailedSub.Data += data =>
            {
                Debug.Log("signalR login failed");
            };

            var _gameStartSub = _hubProxy.Subscribe("GameStarted");
            _gameStartSub.Data += data =>
            {
                Debug.Log("signalR game start");
            };

            var _startGameSub = _hubProxy.Subscribe("StartGame");
            _startGameSub.Data += data =>
            {
                Debug.Log("signalR start game");
            };

            _hubConnection.Start();
        }
        else
        {
            Debug.Log("SignalR already connected...");
        }
    }

    /// <summary>
    /// Send single message of direction over broadcast
    /// </summary>
    // Update is called once per frame
    public void Send(string method, string message)
    {
        if (!useSignalR)
            return;

        var json = "{" + string.Format("\"action\": \"{0}\", \"value\": {1}", method, message) + "}";
        _hubProxy.Invoke("Send", "UnityClient", json);

    }

    public void Login(string userName)
    {
        if(!useSignalR)
            return;
        _hubProxy.Invoke("Login", userName);
        Debug.Log(userName);
    }

    public void CreateGame()
    {
        if(!useSignalR)
            return;
        _hubProxy.Invoke("JoinGame", "test");
    }

}
