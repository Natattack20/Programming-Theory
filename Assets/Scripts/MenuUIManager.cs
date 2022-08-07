using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public InputField inputField;
    public Button start;
    public Button cat;
    public Button dog;
    public Button cow;
    public Button rabbit;
    private bool startGame = false;

    public void StartButton()
    {
        if (startGame == true)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ValueChanged()
    {
        startGame = true;
    }

    // Helps with Inheritance, Encapsulation is done with the input field itself
    public void CowPressed()
    {
        MainManager.instance.animalName = "Cow";
    }
    public void CatPressed()
    {
        MainManager.instance.animalName = "Cat";
    }
    public void DogPressed()
    {
        MainManager.instance.animalName = "Dog";
    }
    public void RabbitPressed()
    {
        MainManager.instance.animalName = "Rabbit";
        Debug.Log("Rabbit");
    }

}
