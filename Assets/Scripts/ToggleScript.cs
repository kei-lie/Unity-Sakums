using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject bean;
    public GameObject teddy;
    public GameObject car;
    public GameObject granny;
    public GameObject ToggleLeft;
    public GameObject ToggleRight;
    public GameObject CharacterImage;
    public Sprite[] characterSprites;
    public GameObject sizeSlider;
    public GameObject rotationSlider;

    public void ToggleBean(bool value)
    {
        bean.SetActive(value);
        ToggleLeft.GetComponent<Toggle>().interactable = value;
        ToggleRight.GetComponent<Toggle>().interactable = value;
    }

    /* public void ToLeft()
     {
         bean.transform.localScale = new Vector2(1, 1);
     }
     public void ToRight()
     {
         bean.transform.localScale = new Vector2(-1, 1);
     }
    */
    public void ToggleFlip(int x)
    {
        bean.transform.localScale = new Vector3(x, 1);
    }
    public void ToggleTeddy(bool value)
    {
        teddy.SetActive(value);
    }
    public void ToggleCar(bool value)
    {
        car.SetActive(value);
    }
    public void ToggleGranny(bool value)
    {
        granny.SetActive(value);
    }

    public void ChangeCharacterImage(int index)
    {
        CharacterImage.GetComponent<Image>().sprite = characterSprites[index];
    }

    public void ChangeRotation()
    {
        float rotationValue = rotationSlider.GetComponent<Slider>().value;
        CharacterImage.transform.localRotation = Quaternion.Euler(0, 0, 360 * rotationValue);
    }
    public void ChangeSize()
    {
        float sizeValue = sizeSlider.GetComponent<Slider>().value;
        CharacterImage.transform.localScale = new Vector2(1f * sizeValue, 1f * sizeValue);
    }
}
