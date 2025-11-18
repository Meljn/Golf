using UnityEngine;

namespace Golf
{
    public class GameStateMechine:MonoBehaviour
    {
        [SerializeField] private MainMenuState m_mainMenuState;
        [SerializeField] private GameplayState m_gameplayState;
        [SerializeField] private BoostrapState m_boostrapState;


        private void Awake()
        {
            m_mainMenuState.Initialize(this);
            m_gameplayState.Initialize(this);
        }

        private void Start()
        {
            Enter<MainMenuState>();
        }
        public void Enter<T>()
        {
            if (typeof(T) == typeof(BoostrapState))
            {
                m_boostrapState.Enter();
            }
            
            if (typeof(T) == typeof(MainMenuState))
            {
                m_boostrapState.Exit();
                m_mainMenuState.Enter();
            }
            
            if (typeof(T) == typeof(GameplayState))
            {
                m_mainMenuState.Exit();
                m_gameplayState.Enter();
            }
        }
    }
}