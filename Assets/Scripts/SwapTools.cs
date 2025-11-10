using NUnit.Framework;
using UnityEngine;

public class SwapTools : MonoBehaviour
{
    [SerializeField] private Transform[] tools;

    public void Swap()
    {
        if (tools.Length < 2) return;

        Transform[] parents = new Transform[tools.Length];
        for (int i = 0; i < tools.Length; i++)
            parents[i] = tools[i].parent;

        for (int i = 0; i < tools.Length; i++)
        {
            int r = Random.Range(i, tools.Length);
            Transform temp = tools[i];
            tools[i] = tools[r];
            tools[r] = temp;
        }

        for (int i = 0; i < tools.Length; i++)
        {
            tools[i].SetParent(parents[i]);
            tools[i].localPosition = Vector3.zero;
            tools[i].localRotation = Quaternion.identity;
        }
    }
}
