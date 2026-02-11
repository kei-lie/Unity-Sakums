using TMPro;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

    SFXScript sfx;
    public TMP_Text counterText;
    private int destroyedDonuts = 0;

    void Start()
    {
        sfx = FindFirstObjectByType<SFXScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Donut"))
        {
            Destroy(collision.gameObject);
            destroyedDonuts++;
            sfx.PlaySFX(0);
            counterText.text = "Donuts Destroyed: \n" + destroyedDonuts;
        }
    }

}
