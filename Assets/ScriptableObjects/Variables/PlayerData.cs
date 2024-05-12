using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "ScriptableObjects/Variable/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float maxHealth;
    public SpriteLibraryAsset SpriteLibraryAsset;
    public float currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    [SerializeField]
    private float _currentHealth;

    [Multiline]
    public string DeveloperDescription = "";
}