using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivoxUnity;
using UnityEngine.UI;

public class VoiceManager : MonoBehaviour {

    VivoxVoiceManager vivox;
    Client client = new Client();
    [SerializeField] InputField inputUsername;
    [SerializeField] InputField inputChannelName;
    [SerializeField] Text textUsername;
    [SerializeField] Text textChannelName;
    [SerializeField] GameObject menu;
    private Transform playerTransform;
    private Transform cachedPlayerTransform;
    public float nextPosUpdate = 0f;

    public void setTarget(Transform target) {
        playerTransform = target;
        Debug.Log("## TARGET SET");
    }

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
                ChannelType.Positional, 
                VivoxVoiceManager.ChatCapability.AudioOnly);
            textChannelName.text = inputChannelName.text;
		}
        menu.SetActive(false);   
    }

    public IChannelSession GetChannel() {
        foreach (var channel in vivox.ActiveChannels) {
            return channel;
		}
        return null;
	}

    public void Update() {
        if (Time.time > nextPosUpdate) {
            Update3DPostion(playerTransform);
            nextPosUpdate = Time.time + 0.3f;
        }
    }

    public void Update3DPostion(Transform pos) {
        if (pos != cachedPlayerTransform) {
            cachedPlayerTransform = pos;
            Debug.Log(pos == null);
            GetChannel()?.Set3DPosition(
                pos.position,
                pos.position,
                pos.forward,
                pos.up);
            Debug.Log("## Updated position");
        }
    }

}
