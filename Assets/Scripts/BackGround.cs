using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;

    public bool canScrolling;

    private float offset;

    private MeshRenderer render;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        canScrolling = true;
    }

    void Update()
    {
        if(canScrolling)
        {
            offset += Time.deltaTime * speed;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}