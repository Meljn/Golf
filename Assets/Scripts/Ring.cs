using System;
using UnityEngine;

namespace Golf
{
    public class Ring : MonoBehaviour
    {
        public Action<Ring> Hit;

        [SerializeField][Min(1)] private int m_scoreMultiplier = 2;

        [SerializeField] private FloatingText m_floatingTextPrefab;

        private ScoreManager m_scoreManager;

       

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.TryGetComponent<StoneComponent>(out var stone))
            {
                ApplyMultiplier();

                if (m_floatingTextPrefab != null)
                {
                    var floatingText = Instantiate(m_floatingTextPrefab, transform.position, transform.rotation);
                    floatingText.Initialize($"+{m_scoreMultiplier}");
                }

                Hit?.Invoke(this);
            }
        }

        private void ApplyMultiplier()
        {
            m_scoreManager.Increase(m_scoreMultiplier);
        }

        public void SetScoreManager(ScoreManager scoreManager)
        {
            m_scoreManager = scoreManager;
        }
    }
}
