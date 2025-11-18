using TMPro;
using UnityEngine;

namespace Golf
{
    public class GameOverState:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private ScoreManager m_scoreManager;
        
        private GameplayState m_gameplayState;

        public void Initialize(GameplayState gameplayState)
        {
            m_gameplayState = gameplayState;
            m_gameOverPanel.gameObject.SetActive(false);
        }

        public void Enter()
        {
            m_scoreText.text = "Score: " + m_scoreManager.score.ToString();
            m_backMainMenu.onClick.AddListener(OnClicked);
            m_gameOverPanel.gameObject.SetActive(true);
        }
        
        private void OnClicked() => m_gameStateMechine.Enter<MainMenuState>();
    }
}