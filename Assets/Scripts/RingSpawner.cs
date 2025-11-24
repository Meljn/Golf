using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Golf
{
    public class RingSpawner : MonoBehaviour
    {
        [SerializeField] private Ring m_ringPrefab;
        [SerializeField] private Transform[] m_spawnPoints;
        [SerializeField] private ScoreManager m_scoreManager;
        [SerializeField] private GameObject m_particleHit;
        private Ring m_ring;

        private void Start ()
        {
            SpawnRing();
        }

        private void SpawnRing()
        {
            if (m_ring == null)
            {
                m_ring = Instantiate(m_ringPrefab);

                m_ring.SetScoreManager(m_scoreManager);

                m_ring.Hit += OnRingHit;
            }

            Transform spawnPoint = m_spawnPoints[Random.Range(0, m_spawnPoints.Length)];
            m_ring.transform.position = spawnPoint.position;
            m_ring.gameObject.SetActive(true);

        }

        private void OnRingHit(Ring ring)
        {
            m_ring.gameObject.SetActive(false);

            Instantiate(m_particleHit, m_ring.transform.position, m_ring.transform.rotation);

            SpawnRing();
        }

    }
}
