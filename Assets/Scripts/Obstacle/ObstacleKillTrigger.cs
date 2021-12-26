using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleKillTrigger : MonoBehaviour
{
  public Transform particlePos;
    [SerializeField] private GameObject trap;
    
    public void Trigger()
    {
        trap.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}