using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;
    private Renderer rend;

    private void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        rend.sortingOrder = (int)(sortingOrderBase - transform.position.y);
    }
}
