using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackGround : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;

    public bool canScrolling = true;

    private float offsetX;
    private float offsetY;

    private MeshRenderer render;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        canScrolling = true;
    }

    void Update()
    {
        if (canScrolling)
        {
            offsetX += Time.deltaTime * speedX;
            offsetY += Time.deltaTime * speedY;
            render.material.mainTextureOffset = new Vector2(offsetX, offsetY);
        }
    }
}
