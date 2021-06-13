using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public static event Action<Transform> PlayerDeathFunc;
    public static event Action GameOverFunc;

    const string hurtAnimString = "Hurt";

    [SerializeField] bool isMaster = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (isMaster == false)
            {
                PlayerDeathFunc?.Invoke(transform);
                //TriggerHurtAnim();
                Destroy(gameObject);
            }
            else
            {
                Time.timeScale = 0;
                StartCoroutine("GameOver");
            }
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameOverFunc?.Invoke();
    }

    private void TriggerHurtAnim()
    {
        Animator animator = GetComponent<Animator>();
        if (animator == null) return;
        animator.SetBool(hurtAnimString, true);
        animator.SetBool(hurtAnimString, false);
    }
}
