using UnityEngine;

namespace Golf
{
    public class StoneSpawner : MonoBehaviour
    {
        [SerializeField] private StoneComponent[] m_prefabs;
        [SerializeField] private Transform m_spawnPoint;
        [SerializeField] private float m_spawnRadius = 0.5f;
        [SerializeField] private GameObject m_particle;


        public StoneComponent Spawn()
        {
            var prefab = m_prefabs[Random.Range(0, m_prefabs.Length)];
            Vector3 randomOffset = Random.insideUnitSphere * m_spawnRadius;
            Vector3 spawnPosition = m_spawnPoint.position + randomOffset;

            Instantiate(m_particle, transform.position, transform.rotation);
            return Instantiate(prefab, spawnPosition, m_spawnPoint.rotation);
        }
    } 
}