using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState:StateBase
    {
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private Button m_backMainMenu;
        [SerializeField] private ScoreManager m_scoreManager;
        
        private GameStateMechine m_gameStateMechine;

        public override void Initialize(GameStateMechine gameStateMechine)
        {
            m_gameStateMechine = gameStateMechine;

            m_gameOverPanel.gameObject.SetActive(false);
        }

        public override void Enter()
        {
            m_scoreText.text = m_scoreManager.score.ToString();

            var record = PlayerPrefs.GetInt(GlobalConstants.Record, 0);
            if (record < m_scoreManager.score)
            {
                PlayerPrefs.SetInt(GlobalConstants.Record, m_scoreManager.score);
            }
            
            m_backMainMenu.onClick.AddListener(OnClicked);
            m_gameOverPanel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            m_gameOverPanel.gameObject.SetActive(false);
            m_backMainMenu?.onClick.RemoveListener(OnClicked);
        }
        
        private void OnClicked() => m_gameStateMechine.Enter<MainMenuState>();
    }
}