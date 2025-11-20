using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState:MonoBehaviour
    {
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private Button m_backMainMenu;
        [SerializeField] private ScoreManager m_scoreManager;
        
        private GameStateMechine m_gameStateMechine;

        public void Initialize(GameStateMechine gameStateMechine)
        {
            m_gameStateMechine = gameStateMechine;

            m_gameOverPanel.gameObject.SetActive(false);
        }

        public void Enter()
        {
            m_scoreText.text = m_scoreManager.score.ToString();
            m_backMainMenu.onClick.AddListener(OnClicked);
            m_gameOverPanel.gameObject.SetActive(true);
        }

        public void Exit()
        {
            m_gameOverPanel.gameObject.SetActive(false);
            m_backMainMenu?.onClick.RemoveListener(OnClicked);
        }
        
        private void OnClicked() => m_gameStateMechine.Enter<MainMenuState>();
    }
}