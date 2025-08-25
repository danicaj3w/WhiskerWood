using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour
{
    public Image staminaBarFill;
    
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDrainRate = 10f; 
    // public float staminaRegenRate = 5f; 
    // public float regenDelay = 2f;

    private Coroutine regenCoroutine;

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar();
    }

    // DrainStamina and StartRegen called when the player is moving
    public void DrainStamina()
    {
        if (currentStamina > 0)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Max(currentStamina, 0);
            UpdateStaminaBar();
        }

        // Stop regen coroutine if player is draining stamina
        if (regenCoroutine != null)
        {
            StopCoroutine(regenCoroutine);
            regenCoroutine = null;
        }
    }

    public void StartRegen(float regenDelay, float staminaRegenRate)
    {
        if (regenCoroutine == null)
        {
            Debug.Log("Starting regen");
            regenCoroutine = StartCoroutine(RegenStamina(regenDelay, staminaRegenRate));
        }
    }

    public float GetCurrentStamina()
    {
        return currentStamina;
    }

    public void AddStamina(int stamina)
    {
        currentStamina += stamina;
    }

    IEnumerator RegenStamina(float regenDelay, float staminaRegenRate)
    {
        Debug.Log("Current stamina values: " + currentStamina);
        // Wait before starting regeneration
        yield return new WaitForSeconds(regenDelay);

        while (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Min(currentStamina, maxStamina);
            UpdateStaminaBar();
            yield return null;
        }
    }

    private void UpdateStaminaBar()
    {
        staminaBarFill.fillAmount = currentStamina / maxStamina;
    }
}