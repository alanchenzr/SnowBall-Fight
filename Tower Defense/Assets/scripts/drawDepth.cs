using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawDepth : MonoBehaviour
{
    private int initial_order;
    
    // Start is called before the first frame update
    void Start()
    {
        initial_order = GetComponent<SpriteRenderer>().sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1 +(20*100) +initial_order;
    }
}
