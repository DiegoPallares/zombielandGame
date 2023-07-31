using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    //para el icono de exclamacion
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private bool isPlayerInRange;
    private bool dialogueStart;
    private int LineIndex;
    private float typingTime = 0.05f;


    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire1")){
            if(!dialogueStart){
                StarDialogue();
            }
            else if (dialogueText.text == dialogueLines[LineIndex]){
                NextDialogueLine();
            }
            else{
                StopAllCoroutines();
                dialogueText.text = dialogueLines[LineIndex];
            }
        }
    }

    private void StarDialogue(){
        dialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(true);
        LineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;

        foreach(char Caracter in dialogueLines[LineIndex]){
            dialogueText.text += Caracter;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void NextDialogueLine(){
        LineIndex++;
        if(LineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else{
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D collision){
        
        if(collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
