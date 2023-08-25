using UnityEngine;

public class AnimateButton : MonoBehaviour
{
    public Animator m_animator;
    private string runParameter = "Run";
    private bool isRunning = false;
    /*
    public AudioSource m_audioSource;
    public AudioClip m_animationSound;

    private bool isSoundPlaying = false;
    private float soundCooldown = 2f;
    private float cooldownTimer = 0f;

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
    }
    */
    private void OnMouseDown()
    {
        /*if (!isSoundPlaying)
        {*/
        isRunning = !isRunning;
        m_animator.SetBool(runParameter, isRunning);

        /*if (m_audioSource != null && m_animationSound != null)
        {
            m_audioSource.PlayOneShot(m_animationSound);
            isSoundPlaying = true;
        }
    }*/
    }
    public void ReceiveClick()
    {
        OnMouseDown();
    }
}