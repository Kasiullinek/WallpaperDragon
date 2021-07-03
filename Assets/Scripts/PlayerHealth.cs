using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int amountOfHealthToBeDead;
    private int currentHealth;
    public bool isGameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = amountOfHealthToBeDead;
        healthSlider.value = 0;
        healthSlider.fillRect.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLives(int amount)
    {
        if(isGameActive == true)
        {
            currentHealth += amount;
            healthSlider.fillRect.gameObject.SetActive(true);
            healthSlider.value = currentHealth;

            if(currentHealth >= amountOfHealthToBeDead)
            {
                Debug.Log("Game Over");
                isGameActive = false;
            }
        }
        
    }
}
