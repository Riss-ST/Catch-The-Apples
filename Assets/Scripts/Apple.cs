using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
     public enum ItemType { Apple, Booster, Bomb }

    [SerializeField] private float timeAmount = 5f;
    [SerializeField] private ItemType item;

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Boundary")){

            Destroy(gameObject);
            return;
        }

        if(other.CompareTag("Box"))
        {
            
            if(item == ItemType.Apple){
                GameManager.instance.AddScore();
            }

            else if(item == ItemType.Booster){
                GameManager.instance.AddTime(timeAmount);
            }

            else if(item == ItemType.Bomb){
                GameManager.instance.ReduceTime(timeAmount);
            }
            Destroy(gameObject);
        }
    }
}
