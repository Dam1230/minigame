using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator weaponAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Space ������ ����
        {
            weaponAnimator.SetTrigger("Attack");
        }
    }
}
