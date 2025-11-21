using UnityEngine;
using UnityEngine.Events;

// Add this script to a UI object with a Text - TextMeshPro component
// It contains methods that can be called from UnityEvents to change the value of the counter.
// For example to count pickups or display health
public class UICounter : MonoBehaviour
{
    [Tooltip("The Text component where the counter value should be shown")]
    [SerializeField] private TMPro.TMP_Text counterText;

    private int counter = 0;

    public UnityEvent onComparedAndTrue;
    
    // AddToCounter adds the value to the current counter-value. Use a negative value if you want to subtract.
    // Can be used to count pickups by adding one for each pickup that is picked up.
    public void AddToCounter(int add)
    {
        counter += add;
        counterText.text = counter.ToString();
    }

    
    // SetCounter gives the counter a new value.
    // Can be used to reset the counter when the player dies.
    public void SetCounter(int set)
    {
        counter = set;
        counterText.text = counter.ToString();
    }

    // Compares a number (other), if they are the same - invoke the onComparedAndTrue Unity Event
    public void CompareCounter(int other)
    {
        if (other == counter)
        {
            onComparedAndTrue.Invoke();
        }
    }
}
