using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    [SerializeField] QuestCompletion qCompl;

    public static int maxQuantity = 6;
    public int quantity = 0;

    public static Collectable Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public void FixedUpdate()
    {
        ////collectScore.text = $"{quantity} / {maxQuantity}";
        //if (quantity == 1)
        //{
        //    qCompl.CompleteObjective();
        //    Destroy(gameObject);
        //    //enemyText.SetActive(true);
        //}
    }
}
