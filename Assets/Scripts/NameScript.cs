using UnityEngine;
using TMPro;

public class NameScript : MonoBehaviour
{
    private string text;
    private string[] input = { "Sveiks", "Jauku dienu", "Prieks tevi redzēt", "Uz redzēšanos", "Jauki, ka atnāci!", "Tiksimies rīt" };
    private int rand;
    public GameObject inputField;
    public GameObject textField;

    public void GetText()
    {
        rand = Random.Range(0, input.Length);
        text = inputField.GetComponent<TMP_InputField>().text;
        textField.GetComponent<TMP_Text>().text = input[rand] + "" + text+"!";
            }
}
