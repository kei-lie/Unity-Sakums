using TMPro;
using UnityEngine;

public class ObjectCatchScript : MonoBehaviour
{
    public float sizeIncrease = 0.5f;
    public float massIncrease = 1f;
    public TMP_Text counterText;
    private Rigidbody2D rb;
    SFX_Script sfx;

    
    public GameObject textField;
    private int life = 3;
    private DonutBakerScript BD;

    private DonutCounter dm;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.IsChildOf(transform))
            return;
        
        if(collision.CompareTag("Donut")) {
            sfx.PlaySFX(4);
            Destroy(collision.gameObject);
            transform.localScale += new Vector3(sizeIncrease, sizeIncrease, 0);
            rb.mass += massIncrease;

            dm.donutCounter++;



        } else if (collision.CompareTag("Asteroid"))
        {
            sfx.PlaySFX(4);
            Destroy(collision.gameObject);
            life = life-1;

            if (life == 0)
            {
                BD.BakeDonut(false);
                textField.GetComponent<TMP_Text>().text = "Game Over";
            }

        }
        else
            Debug.Log("Collided with non-donut and non-asteroid object: " + collision.gameObject.name);
    }
}
