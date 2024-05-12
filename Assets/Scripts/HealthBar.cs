using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerData playerData;
    public Image healthBar;
    //public Gradient gradient;
    

    public void Update()
    {
        healthBar.fillAmount = playerData.currentHealth / playerData.maxHealth;
        // Évaluer le dégradé en fonction du remplissage de la barre de vie
        //healthBar.color = gradient.Evaluate(healthBar.fillAmount);
    }

    
}
