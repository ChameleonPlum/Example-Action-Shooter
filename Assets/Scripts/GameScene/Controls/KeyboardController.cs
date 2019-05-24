using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {

    private static Vector2 inputVector = Vector2.zero;
    public static float getHorizontal { get { return inputVector.x; } }
    public static float getVertical { get { return inputVector.y; } }

    private static Vector2 inputMouseVector = Vector2.zero;
    public static float getMouseHorizontal { get { return inputMouseVector.x; } }
    public static float getMouseVertical { get { return inputMouseVector.y; } }

	void Update ()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        inputMouseVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * 2;
    }
}
