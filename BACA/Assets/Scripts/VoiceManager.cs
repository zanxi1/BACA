﻿using System.Collections;
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
    public Transform playerTransform;
    private Vector3 cachedPlayerTransform = new Vector3();
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
            //Channel3DProperties prop = new Channel3DProperties(2,1,1.0f,AudioFadeModel.InverseByDistance);
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
        Debug.Log("## Update");
        Debug.Log(Time.time);
        Debug.Log(nextPosUpdate);
        Debug.Log(Time.time > nextPosUpdate);
        if (Time.time > nextPosUpdate) {
            Debug.Log(playerTransform.position);
            Update3DPostion(playerTransform);
            nextPosUpdate = Time.time + 0.3f;
            Debug.Log("Updated Time");
        }
    }

    public void Update3DPostion(Transform pos) {
        if (pos.position != cachedPlayerTransform) {
            cachedPlayerTransform = pos.position;
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
