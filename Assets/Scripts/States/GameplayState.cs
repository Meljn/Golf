using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

namespace Golf
{
    public class GameplayState:StateBase
    {

        [SerializeField] private GameObject m_gameplayPanel;
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private PlayerController m_playerController;

        private GameStateMechine m_gameStateMechine;
        
        public override void Initialize(GameStateMechine gameStateMechine)
        {
            m_gameplayPanel.SetActive(false);
            m_gameStateMechine = gameStateMechine;
        }

        public override void Enter()
        {
            m_scoreManager.Reset();
            m_scoreManager.ScoreChanged += OnScoreChanged;

            m_gameplayPanel.SetActive(true);
            m_scoreText.text = m_scoreManager.score.ToString();

            m_levelController.enabled = true;
            m_playerController.enabled = true;

            m_levelController.Finished += OnFinished;
        }

        private void OnFinished()
        {
            m_gameStateMechine.Enter<GameOverState>();
        }

        public override void Exit()
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_gameplayPanel.SetActive(false);

            m_levelController.Finished -= OnFinished;
        }
        
        private void OnScoreChanged(int score)
        {
            m_scoreText.text = score.ToString();
        }
    }
}