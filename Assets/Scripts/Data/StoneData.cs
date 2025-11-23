using UnityEngine;

namespace Golf.Data
{
    [CreateAssetMenu(fileName = "New StoneData", menuName = "StoneData")]
    public class StoneData : ScriptableObject
    {
        [SerializeField] private int m_score;
        [SerializeField] GameObject m_particle;

        public int score => m_score;

        public GameObject particle => m_particle;

    }
}