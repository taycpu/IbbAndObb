using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Datas/Create PlayerInput", fileName = "PlayerInput", order = 0)]
public class PlayerInput : ScriptableObject
{
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;
    public float horizontal;

    public float GetHorizontalAxis()
    {
        if (Input.GetKey(left))
        {
            horizontal = -1;
        }

        if (Input.GetKey(right))
        {
            horizontal = 1;
        }

        bool notPressed = (Input.GetKey(right)==false&& Input.GetKey(left)==false);
        bool isBoth = (Input.GetKey(right) && Input.GetKey(left));
        if ((isBoth || notPressed))
        {
            horizontal = 0;
        }


        return horizontal;
    }
}