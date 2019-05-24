using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields

    [SerializeField]
    private byte maxPlayersPerRoom = 8;

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Text startButtonText;

    [SerializeField]
    private Text infoText;
    #endregion


    #region Private Fields

    string gameVersion = "1";
    private DebugLogger logger = new DebugLogger();

    #endregion


    #region MonoBehaviourPunCallbacks Callbacks


    public override void OnConnectedToMaster()
    {
        logger.Log(this, "PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        logger.LogWarning(this, "PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0} " + cause);
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        logger.Log(this, "PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");  
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        logger.Log(this, "PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            PhotonNetwork.LoadLevel("Game");
    }

    #endregion


    #region MonoBehaviour CallBacks

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            startButton.onClick.AddListener(Connect);
        }

    #endregion


    #region Public Methods
    public void Connect()
    {
        startButtonText.text = "Cancel";
        infoText.text = "Connection...";
        if (PhotonNetwork.IsConnected)
        {         
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {             
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    #endregion


}
