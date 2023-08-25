using System.Collections;
using UnityEngine;

public class AnimateButton : MonoBehaviour
{
    public Animator m_animator;
    private bool isRunning = false;

    public AudioSource m_audioSource;
    public AudioClip m_animationSound;

    private bool isSoundPlaying = false;
    private float soundCooldown = 2f;
    private float cooldownTimer = 0f;

    public Transform target;
    public GameObject zombi;
    public float wait;

    private void Update()
    {
        if (isSoundPlaying)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= soundCooldown)
            {
                isSoundPlaying = false;
                cooldownTimer = 0f;
            }
        }

        if (isRunning == true)
        {
            StartCoroutine(WaitToRun());
        }
    }
    IEnumerator WaitToRun()
    {
        yield return new WaitForSeconds(wait);
        zombi.transform.position = Vector3.MoveTowards(zombi.transform.position, target.transform.position, Time.deltaTime * 2F);
    }
    private void OnMouseDown()
    {
        if (!isSoundPlaying)
        {
            isRunning = !isRunning;

            m_animator.CrossFade("Z_Run", 0.2f);

            if (m_audioSource != null && m_animationSound != null)
            {
                m_audioSource.PlayOneShot(m_animationSound);
                isSoundPlaying = true;
            }
        }
    }
}