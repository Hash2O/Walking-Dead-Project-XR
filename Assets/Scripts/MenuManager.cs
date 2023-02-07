using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private InputActionReference _menuAction;

    [SerializeField] private GameObject _menu;

    // Start is called before the first frame update
    void Start()
    {
        _menuAction.action.Enable();
        _menuAction.action.performed += DisplayMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayMenu(InputAction.CallbackContext obj)
    {
        if(_menu.activeSelf)
        {
            _menu.SetActive(false);
        }
        else
        {
            _menu.SetActive(true);
        }
    }
}
