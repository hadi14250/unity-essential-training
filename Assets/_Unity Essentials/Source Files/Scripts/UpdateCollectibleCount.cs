using UnityEngine;
using TMPro;
using System; // Required for Type handling

public class UpdateCollectibleCount : MonoBehaviour
{
    private TextMeshProUGUI collectibleText; // Reference to the TextMeshProUGUI component
    private Type collectible2DType;
    private int initialTotalCollectibleAmmount;

    void Start()
    {
        // Initialize the collectible2DType
        collectible2DType = Type.GetType("Collectible2D");

        // Calculate initial total collectible amount
        if (collectible2DType != null)
        {
            initialTotalCollectibleAmmount = UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }
        else
        {
            initialTotalCollectibleAmmount = 0;
            Debug.LogError("Collectible2D type not found. Make sure the class name is correct.");
        }

        // Get the TextMeshProUGUI component
        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }

        UpdateCollectibleDisplay(); // Initial update on start
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        // Check and count objects of type Collectible2D as well if needed
        if (collectible2DType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        // Update the collectible count display
        collectibleText.text = $"Collectibles remaining: {totalCollectibles} out of {initialTotalCollectibleAmmount}";
    }
}
