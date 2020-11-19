using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;
    AudioSource footstep;

    private void Start()
    {
        footstep = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
            
        if ((velocity.y!=0)||(velocity.x !=0))
        {
            if (!footstep.isPlaying)
            {
                footstep.Play();
            }
        }
        else
        {
            footstep.Stop();
        }

    }
}
