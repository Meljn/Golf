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

        private Ring m_ring;

        private void Start ()
        {
            SpawnRing();
        }

        private void SpawnRing()
        {
            if (m_ring == null)
            {
                Debug.Log("Создаём новое кольцо!");
                m_ring = Instantiate(m_ringPrefab);

                m_ring.SetScoreManager(m_scoreManager);

                m_ring.Hit += OnRingHit;
            }

            Transform spawnPoint = m_spawnPoints[Random.Range(0, m_spawnPoints.Length)];
            m_ring.transform.position = spawnPoint.position;
            m_ring.gameObject.SetActive(true);
            Debug.Log($"Кольцо активировано в позиции: {m_ring.transform.position}");
        }

        private void OnRingHit(Ring ring)
        {
            m_ring.gameObject.SetActive(false);
            SpawnRing();
        }

    }
}
