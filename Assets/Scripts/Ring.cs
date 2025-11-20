using UnityEngine;

namespace Golf
{
    public class Ring : MonoBehaviour
    {
        [SerializeField][Min(1)] private int m_scoreMultiplier = 2;
        [SerializeField] private ScoreManager m_scoreManager;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<StoneComponent>(out var stone))
            {
                ApplyMultiplier();
            }
        }

        private void ApplyMultiplier()
        {
            for (int i = 0; i < m_scoreMultiplier; i++)
            {
                m_scoreManager.Increase();
            }
        }
    }
}
