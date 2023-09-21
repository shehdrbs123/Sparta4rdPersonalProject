using System;
using Practice.Scripts.Managers;
using UnityEngine;
namespace Practice.Scripts
{
    public class Actor : MonoBehaviour 
    {
        [SerializeField] protected string nameID;
        protected static OnlineUserManager OnlineUserManager;
        public event Action OnNameChanged;
        
        protected virtual void Awake()
        {
            OnlineUserManager = GameManager.Instance.onlineUserManager;
        }

        private void RegistToGameDataManager()
        {
#if UNITY_EDITOR
            if (nameID == null)
            {
                nameID = name;
            }
#endif
            nameID = OnlineUserManager.Regist(nameID,this);   
        }

        private void RemoveToGameDataManager()
        {
            OnlineUserManager.CancelRegist(nameID);
        }

        public void ChangeRegistName(string newName)
        {
            OnlineUserManager.CancelRegist(nameID);
            nameID = newName;
            OnlineUserManager.Regist(nameID, this);
            OnNameChanged?.Invoke();
        }
        
        /// <summary>
        /// 오버라이드가 필요할 경우 기존 메소드 먼저 실행해 주세요
        /// </summary>
        protected virtual void OnEnable()
        {
            RegistToGameDataManager();
        }
        
        /// <summary>
        /// 오버라이드가 필요할 경우 기존 메소드 먼저 실행해 주세요
        /// </summary>
        protected virtual void OnDisable()
        {
            RemoveToGameDataManager();
        }

        public string GetName()
        {
            return nameID;
        }
    }
}