
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private TopDownCharacterController1 _controller1;

    private GameObject InventoryUI;
    private GameObject StatusUI;
    void Awake()
    {
        _controller1 = GetComponent<TopDownCharacterController1>();
    }

    void Start()
    {
        UIManager manager = GameManager.Instance.UIManager;
        
        InventoryUI = manager.GetUI("InventoryUI");
        StatusUI = manager.GetUI("StatusUI");
        
        InventoryUI.SetActive(false);
        StatusUI.SetActive(false);

        _controller1.OnInventoryEvent += () => { InventoryUI.SetActive(!InventoryUI.activeSelf); };
        _controller1.OnStatusEvent += () => { StatusUI.SetActive(!StatusUI.activeSelf); };
    }
}
