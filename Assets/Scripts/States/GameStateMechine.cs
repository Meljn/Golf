using UnityEngine;

namespace Golf
{
    public class GameStateMechine:MonoBehaviour
    {
        [SerializeField] private MainMenuState m_mainMenuState;
        [SerializeField] private GameplayState m_gameplayState;
        [SerializeField] private BoostrapState m_boostrapState;
        [SerializeField] private GameOverState m_gameoverState;


        private void Awake()
        {
            m_mainMenuState.Initialize(this);
            m_gameplayState.Initialize(this);
            m_boostrapState.Initialize(this);
            m_gameoverState.Initialize(this);
        }

        private void Start()
        {
            Enter<BoostrapState>();
        }
        public void Enter<T>()
        {
            if (typeof(T) == typeof(BoostrapState))
            {
                m_boostrapState.Enter();
            }
            
            else if (typeof(T) == typeof(MainMenuState))
            {
                m_gameplayState.Exit();
                m_mainMenuState.Enter();
                m_gameoverState.Exit();             
            }
            
            else if (typeof(T) == typeof(GameplayState))
            {
                m_boostrapState.Exit();
                m_mainMenuState.Exit();
                m_gameoverState.Exit();
                m_gameplayState.Enter();
            }

            else if (typeof(T) == typeof(GameOverState))
            {
                m_gameplayState.Exit();
                m_gameoverState.Enter();
            }

        }
    }
}