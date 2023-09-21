
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractController : MonoBehaviour
{
    private IInteract _currentInteract;
    private TopDownCharacterController1 _controller;
    void Awake()
    {
        _controller = GetComponent<TopDownCharacterController1>();
    }

    private void Start()
    {
        _controller.OnInteractEvent += Interact;
    }

    public IInteract currentInteract
    {
        get
        {
            return _currentInteract;
        }
        set
        {
            _currentInteract.SetOutLine(false);
            _currentInteract = value;
            _currentInteract.SetOutLine(true);
        }
    }

    private void Interact(GameObject Interactee)
    {
        _currentInteract?.Interact(Interactee);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        IInteract interact;
        if (!other.TryGetComponent(out interact))
        {
            return;
        }

        if (_currentInteract == null)
            _currentInteract = interact;
        else if (other)
        {
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        IInteract interact;
        if (!other.TryGetComponent(out interact))
        {
            return;
        }

        if (_currentInteract == interact)
        {
            _currentInteract = null;
        }
    }
}
