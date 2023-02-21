using UnityEngine;

[CreateAssetMenu(menuName = "Config/Game", fileName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("Customization"), SerializeField]
    private ShowingCustomizationType showingCustomization;
    public ShowingCustomizationType ShowingCustomization => showingCustomization;

    public enum ShowingCustomizationType
    {
        /// <summary> Show available and unavailable settings </summary>
        ShowAllSettings,
        
        /// <summary> Hide arrows for unavailable settings </summary>
        ShowPartialUnavailableSettings,
        
        /// <summary> Deactivate unavailable settings </summary>
        DeactivateUnavailableSettings
    }
}