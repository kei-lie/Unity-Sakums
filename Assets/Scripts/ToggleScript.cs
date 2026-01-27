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

    public void ToggleBean(bool value)
    {
        bean.SetActive(value);
        ToggleLeft.GetComponent<Toggle>().interactable = value;
        ToggleRight.GetComponent<Toggle>().interactable = value;
    }

    public void ToLeft()
    {
        bean.transform.localScale = new Vector2(1, 1);
    }
    public void ToRight()
    {
        bean.transform.localScale = new Vector2(-1, 1);
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
}
