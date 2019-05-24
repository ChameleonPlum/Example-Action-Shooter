using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void AttackDelegate();

public class CharacterController : MonoBehaviourPunCallbacks, IPunObservable, IPunInstantiateMagicCallback
{
    private CharacterBase data;
    private Camera camera;

    private IWeapon weapon;
    public IWeapon Weapon { get { return weapon; } }

    private bool isJoystickMove = true;

    void IPunInstantiateMagicCallback.OnPhotonInstantiate(PhotonMessageInfo info)
    {
        object[] data = this.gameObject.GetPhotonView().InstantiationData;
        if (data != null && data.Length == 1)
        {
            gameObject.name = (string)data[0];
        }      
    }

    public void Init(CharacterBase _data, IWeapon _weapon)
    {
        data = _data;
        weapon = _weapon;
    }
    
    private void Awake()
    {   
        if (photonView.IsMine)
        {
            camera = GetComponentInChildren<Camera>(true);
            camera.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            if (isJoystickMove)
            {
                if (Joystick.getHorizontal != 0 && Joystick.getVertical != 0)
                {
                    Vector2 input = new Vector2(Joystick.getHorizontal, Joystick.getVertical).normalized;
                    Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;
                    MoveTo(desiredMove);
                }

                Vector3 eulerAngles = transform.localEulerAngles;
                eulerAngles += JoystickRotation.inputVector;
                transform.localEulerAngles = new Vector3(0, eulerAngles.y, 0);

                Vector3 cameraRotation = camera.transform.localEulerAngles;
                cameraRotation += JoystickRotation.inputVector;
                if (cameraRotation.x > 41 && cameraRotation.x < 50)
                    cameraRotation.x = 41;
                else if (cameraRotation.x < 349 && cameraRotation.x > 300)
                    cameraRotation.x = 349;
                camera.transform.localEulerAngles = new Vector3(cameraRotation.x, 0, 0);
            }
            else
            {
                Vector2 input = new Vector2(KeyboardController.getHorizontal, KeyboardController.getVertical);
                Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;
                MoveTo(desiredMove);

                Vector3 eulerAngles = transform.localEulerAngles;
                eulerAngles += new Vector3(-KeyboardController.getMouseVertical, KeyboardController.getMouseHorizontal, 0);
                transform.localEulerAngles = new Vector3(0, eulerAngles.y, 0);

                Vector3 cameraRotation = camera.transform.localEulerAngles;
                cameraRotation += new Vector3(-KeyboardController.getMouseVertical, KeyboardController.getMouseHorizontal, 0);
                if (cameraRotation.x > 41 && cameraRotation.x < 50)
                    cameraRotation.x = 41;
                else if (cameraRotation.x < 349 && cameraRotation.x > 300)
                    cameraRotation.x = 349;
                camera.transform.localEulerAngles = new Vector3(cameraRotation.x, 0, 0);
            }
        }
    }

    public void ChangeControl(bool _isJoystickMove)
    {
        isJoystickMove = _isJoystickMove;
    }

    private void MoveTo(Vector3 position)
    {
        GetComponent<Rigidbody>().velocity = position * 5;
    }


    public void Damage(float damage)
    {
      
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {          
            stream.SendNext(data.Health);
        }
        else
        {         
            data.Health = (float)stream.ReceiveNext();
        }
    }
}
