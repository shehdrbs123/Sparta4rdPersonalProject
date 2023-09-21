
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractController
{
    private IInteract _currentInteract;

    void Awake()
    {
        
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
    
}
