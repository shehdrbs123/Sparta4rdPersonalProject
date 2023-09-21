using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Practice.Scripts
{
    public class Player : Actor
    {
        [SerializeField] private TextMesh nameTag;
        private SpriteRenderer mainSprite;
        public Sprite MainSprite
        {
            get
            {
                return mainSprite.sprite;
            }
            set
            {
                mainSprite.sprite = value;
                OnJopChanged?.Invoke();
            }
        }
        private int _money;
        public int Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
                OnMoneyChanged?.Invoke();
            }
        }

        public event Action OnMoneyChanged;
        public event Action OnJopChanged;
        protected override void Awake()
        {
            base.Awake();
            OnlineUserManager.Player = gameObject;
            mainSprite = GetComponentInChildren<SpriteRenderer>();
        }

        protected void Start()
        {
            OnNameChanged += nameTagChange;
            nameTagChange();
            Money = 5000;
            DontDestroyOnLoad(gameObject);
        }

        public void nameTagChange()
        {
            nameTag.text = nameID;
        }
        public void StartInit(Scene arg0, LoadSceneMode arg1)
        {
           EnableComponents(true);
        }

        public void EnableComponents(bool isEnable)
        {
            MonoBehaviour[] Components = GetComponents<MonoBehaviour>();
            Array.ForEach(Components,x => x.enabled = isEnable);
        }
    }
}