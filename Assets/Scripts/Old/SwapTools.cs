using UnityEngine;

public class SwapTools : MonoBehaviour
{
    [SerializeField] private Transform[] m_tools;

    public void Swap()
    {
        if (m_tools.Length < 2) return;

        Transform[] parents = new Transform[m_tools.Length];
        for (int i = 0; i < m_tools.Length; i++)
            parents[i] = m_tools[i].parent;

        for (int i = 0; i < m_tools.Length; i++)
        {
            int r = Random.Range(i, m_tools.Length);
            Transform temp = m_tools[i];
            m_tools[i] = m_tools[r];
            m_tools[r] = temp;
        }

        for (int i = 0; i < m_tools.Length; i++)
        {
            m_tools[i].SetParent(parents[i]);
            m_tools[i].localPosition = Vector3.zero;
            m_tools[i].localRotation = Quaternion.identity;
        }
    }
}
