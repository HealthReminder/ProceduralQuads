using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Waits for input to turn on the menu anchor object
/// </summary>
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuObject;
    [SerializeField] private UnityEvent _onCloseEvent; // Event used for the initial screen
    private void Start()
    {
        if (_menuObject.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _onCloseEvent.Invoke();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M)){
            ToggleMenu();
        }

    }
    public void ToggleMenu()
    {
        _menuObject.SetActive(!_menuObject.activeSelf);
        if (_menuObject.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _onCloseEvent.Invoke();
        } else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
