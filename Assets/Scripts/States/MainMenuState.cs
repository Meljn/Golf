using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState:MonoBehaviour
    {
        [SerializeField] private GameObject m_mainMenuRoot;
        [SerializeField] private Button m_playButton;
        private GameStateMechine m_gameStateMechine;

        public void Initialize(GameStateMechine gameStateMachine)
        {
            m_mainMenuRoot.SetActive(false);
            m_gameStateMechine = gameStateMachine;
        }
        
        public void Enter()
        {
            m_mainMenuRoot.SetActive(true);
            m_playButton.onClick.AddListener(OnClicked);
        }
        public void Exit()
        {
            m_mainMenuRoot.SetActive(false);
            m_playButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            m_gameStateMechine.Enter<GameplayState>();
        }
    }
}