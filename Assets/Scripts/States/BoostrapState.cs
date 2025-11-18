using UnityEngine;

namespace Golf
{
    public class BoostrapState:MonoBehaviour
    {
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;
        private GameStateMechine m_gameStateMechine;

        public void Initialize(GameStateMechine gameStateMechine)
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_gameStateMechine = gameStateMechine;
        }

        public void Enter()
        {
            m_gameStateMechine.Enter<MainMenuState>();
        }

        public void Exit()
        {
            
        }
    }
}