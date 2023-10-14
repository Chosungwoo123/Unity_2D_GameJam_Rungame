using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankItem : MonoBehaviour
{
    [SerializeField] private int itemScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlusScore(itemScore);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EffectManager.Instance.MakeItemEatEffect(this.gameObject.transform);
            GameManager.Instance.PlusScore(itemScore);
            gameObject.SetActive(false);
        }
    }
}
