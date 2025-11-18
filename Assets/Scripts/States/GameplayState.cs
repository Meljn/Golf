using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

namespace Golf
{
    public class GameplayState:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private LevelController m_levelController;
        private GameStateMechine m_gameStateMechine;
        [SerializeField] private PlayerController m_playerController;
        
        public void Initialize(GameStateMechine gameStateMechine)
        {
            m_scoreText.gameObject.SetActive(false);
            m_gameStateMechine = gameStateMechine;
        }

        public void Enter()
        {
            m_scoreManager.Reset();
            m_scoreManager.ScoreChanged += OnScoreChanged;
            m_levelController.enabled = true;
            m_playerController.enabled = true;
            m_scoreText.text = m_scoreManager.score.ToString();

            m_levelController.Finished += OnFinished;
        }

        public void Exit()
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
        }
        
        private void OnScoreChanged(int score) => m_scoreText.text = $"Score: {score}";
    }
}