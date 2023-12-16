using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputTester : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 mainButtons;
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

    public void OnFX_L(InputAction.CallbackContext _ctx)
    {
        bool pressed = _ctx.ReadValueAsButton();

        Debug.Log("FX L" + pressed);
    }

    public void OnFX_R(InputAction.CallbackContext _ctx)
    {
        bool pressed = _ctx.ReadValueAsButton();

        Debug.Log("FX R" + pressed);
    }

    public void OnWASDInput(InputAction.CallbackContext _ctx)
    {
        mainButtons = _ctx.ReadValue<Vector2>();

        Debug.Log(mainButtons);
    }


}
