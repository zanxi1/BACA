using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivoxUnity;
using UnityEngine.UI;

public class VoiceManager : MonoBehaviour
{
    VivoxVoiceManager vivox;
    Client client = new Client();
    [SerializeField] InputField inputUsername;
    [SerializeField] InputField inputChannelName;
    [SerializeField] Text textUsername;
    [SerializeField] Text textChannelName;

    void Awake() {
        vivox = VivoxVoiceManager.Instance;
        client.Uninitialize();
        client.Initialize();
        vivox.OnUserLoggedInEvent += LoggedIn;
    }

	private void OnApplicationQuit() {
		if(vivox.LoginState == LoginState.LoggedIn) {
            vivox.Logout();
		}
        client.Uninitialize();
	}

    public void Login() {
        // filter text
        if(!string.IsNullOrEmpty(inputUsername.text))
            vivox.Login(inputUsername.text);
	}

    private void LoggedIn() {
        textUsername.text = vivox.LoginSession.LoginSessionId.DisplayName;
	}

    public void Logout() {
        if (vivox.LoginState == LoginState.LoggedIn) {
            vivox.Logout();
        }
        client.Uninitialize();
    }

    public void JoinChannel() {
        if (!string.IsNullOrEmpty(inputChannelName.text)) {
            vivox.JoinChannel(
                inputChannelName.text, 
                ChannelType.NonPositional, 
                VivoxVoiceManager.ChatCapability.AudioOnly);
            textChannelName.text = inputChannelName.text;
		}
            
    }
}
