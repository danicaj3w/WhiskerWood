using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] StaminaBar staminaBar;

    public void DrainStamina()
    {
        staminaBar.DrainStamina();
    }

    public void StartRegen(float regenDelay, float staminaRegenRate)
    {
        staminaBar.StartRegen(regenDelay, staminaRegenRate);
    }

    public float GetCurrentStamina()
    {
        return staminaBar.GetCurrentStamina();
    }
}
