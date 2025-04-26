using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class StationBehavior : MonoBehaviour
{
    int health = 6;
    
    public void ApplyDamage(int damage){
        health -= damage;
        Debug.Log(health);
        if(health <= 0){
            Destroy(gameObject);
        }
    }
    
}
