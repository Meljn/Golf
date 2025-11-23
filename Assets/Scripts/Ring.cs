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
            m_scoreManager.Increase(m_scoreMultiplier);
        }
    }
}
