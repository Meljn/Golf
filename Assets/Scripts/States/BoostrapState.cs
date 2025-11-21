using UnityEngine;

namespace Golf
{
    public class BoostrapState: StateBase
    {
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;
        private GameStateMechine m_gameStateMechine;

        public override void Initialize(GameStateMechine gameStateMechine)
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_gameStateMechine = gameStateMechine;
        }

        public override void Enter()
        {
            m_gameStateMechine.Enter<MainMenuState>();
        }

        public override void Exit()
        {
            
        }
    }
}