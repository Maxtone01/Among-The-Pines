using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    [SerializeField] QuestCompletion qCompl;
    //Text collectScore;
    //public GameObject enemyText;

    public static int maxQuantity = 6;
    public int quantity = 0;

    public static Collectable Instance { get; private set; }

    private void Start()
    {
        //enemyText.SetActive(false);
        //collectScore = GetComponent<Text>();
        Instance = this;
    }

    public void FixedUpdate()
    {
        //collectScore.text = $"{quantity} / {maxQuantity}";
        if (quantity == 1)
        {
            //enemyText.SetActive(true);
        }
    }
}
