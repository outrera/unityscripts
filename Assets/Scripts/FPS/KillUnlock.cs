using UnityEngine;
using System.Collections;



public class KillUnlock : MonoBehaviour
{
    public int numberToKill = 2;
    public int originalNumber;

    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        originalNumber = enemies.Length;
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (originalNumber - enemies.Length <= numberToKill || enemies.Length == 0)
        {
            gameObject.SetActive(false);
        }
    }

}