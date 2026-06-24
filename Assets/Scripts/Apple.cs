using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public enum ItemType { Apple, Health, Bomb }


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
                Game_Manager.instance.AddScore();
            }

            else if(item == ItemType.Health){
                Game_Manager.instance.AddHealth();
            }

            else if(item == ItemType.Bomb){
                Game_Manager.instance.ReduceHealth();
            }
            Destroy(gameObject);
        }
    }
}
