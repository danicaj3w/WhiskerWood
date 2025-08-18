using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stamina : MonoBehaviour
{
    public Image staminaBarFill;
    
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDrainRate = 10f; 
    public float staminaRegenRate = 5f; 
    public float regenDelay = 2f;

    private Coroutine regenCoroutine;

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaBar();
    }

    void Update()
    {
        // Example: Drain stamina while a button is held down (e.g., 'Left Shift' for sprinting)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            DrainStamina();
        }
        else
        {
            StartRegen();
        }
    }

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

    public void StartRegen()
    {
        if (regenCoroutine == null)
        {
            regenCoroutine = StartCoroutine(RegenStamina());
        }
    }

    public float GetCurrentStamina()
    {
        return currentStamina;
    }

    IEnumerator RegenStamina()
    {
        // Wait before starting regeneration
        yield return new WaitForSeconds(regenDelay);

        while (currentStamina < maxStamina)
        {
            // Regenerate stamina
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