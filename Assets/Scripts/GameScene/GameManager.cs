using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviourPunCallbacks
{
    private Dictionary<int, CharacterController> characters = new Dictionary<int, CharacterController>();

    [SerializeField]
    private Button attackButton;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Toggle toggle;

    private void Start()
    {
        CharacterFactory factory = new CharacterFactory();

        TextAsset data = Resources.Load("Character1") as TextAsset;
        JSONObject obj = new JSONObject(data.ToString());

        TextAsset dataWeapon = Resources.Load("Weapon1") as TextAsset;
        JSONObject objW = new JSONObject(dataWeapon.ToString());

        CharacterController character = factory.Create(obj, objW);

        toggle.onValueChanged.AddListener(character.ChangeControl);

        attackButton.onClick.AddListener(() => 
        {
            Vector3 desiredMove = character.transform.forward * 1.05f + character.transform.right * 0.86f;
            character.Weapon.Attack(character.transform.position + desiredMove, character.transform.rotation.eulerAngles);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !toggle.isOn)
        {
            attackButton.onClick.Invoke();
        }
    }

    private int score;
    private void AddScore()
    {
        scoreText.text = (++score).ToString();
    }

    #region Photon Callbacks
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); 


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

            //////Вызов
        }
    }


    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); 


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); 


            //////Вызов
        }
    }


    #endregion


    #region Public Methods
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    #endregion
}

