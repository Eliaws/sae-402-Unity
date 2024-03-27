using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerData playerData;
    public Image healthBar;

    public void Update()
    {
        healthBar.fillAmount = playerData.currentHealth / playerData.maxHealth;
    }
}
