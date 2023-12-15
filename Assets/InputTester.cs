using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputTester : MonoBehaviour
{
    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseInput(InputAction.CallbackContext _ctx)
    {
        var mouseDelta = _ctx.ReadValue<Vector2>();

        mousePos += mouseDelta;

        Debug.Log(mousePos);
    }

    public void ButtonInput(InputAction.CallbackContext _ctx)
    {
        bool pressed = _ctx.ReadValueAsButton();

        Debug.Log(pressed);
    }


}
