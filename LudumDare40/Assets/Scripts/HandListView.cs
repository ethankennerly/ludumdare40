using System;
using UnityEngine;
using Finegamedesign.Utils;

public sealed class HandListView : MonoBehaviour
{
    [SerializeField]
    private int m_SortingOrder = -1;

    [SerializeField]
    private GameObject[] m_Hands;

    private int m_Index = 0;

    private void OnEnable()
    {
        ScoreTrigger2D.onPickup += Pickup;
    }

    private void OnDisable()
    {
        ScoreTrigger2D.onPickup -= Pickup;
    }

    // Recycles when hands are full.
    private void Pickup(GameObject itemObject)
    {
        Debug.Log("HandListView.Pickup: " + m_Index);
        GameObject handObject = m_Hands[m_Index];
        itemObject.transform.position = Vector3.zero;
        SceneNodeView.AddChild(handObject, itemObject);
        if (m_SortingOrder >= 0)
        {
            SceneNodeView.SetSortingOrder(itemObject, m_SortingOrder);
        }
        ++m_Index;
        if (m_Index >= m_Hands.Length)
        {
            m_Index = 0;
        }
    }
}
