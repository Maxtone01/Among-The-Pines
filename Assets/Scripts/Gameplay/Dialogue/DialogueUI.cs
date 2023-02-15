using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    ConversantController conversantController;
    [SerializeField]
    TextMeshProUGUI speakerText;
    [SerializeField]
    Button nextButton;
    [SerializeField]
    Transform dialogueVariant;
    [SerializeField]
    GameObject dialogueVariantPrefab;


    void Start()
    {
        conversantController = GameObject.FindGameObjectWithTag("Player").GetComponent<ConversantController>();
        nextButton.onClick.AddListener(Next);
        UpdateUI();
    }

    private void Next()
    {
        conversantController.SelectNextDialogueVariant();
        UpdateUI();
    }

    
    void UpdateUI()
    {
        speakerText.text = conversantController.GetText();
        nextButton.gameObject.SetActive(conversantController.HasNext());
        foreach (Transform item in dialogueVariant)
        {
            Destroy(item.gameObject);
        }
        foreach (string choiceText in conversantController.GetChoiceVariants())
        {
            GameObject choice = Instantiate(dialogueVariantPrefab, dialogueVariant);
            TextMeshProUGUI textComponent = choice.GetComponentInChildren<TextMeshProUGUI>();
            textComponent.text = choiceText;
        }
    }
}
