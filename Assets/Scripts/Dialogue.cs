using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Windows
    public GameObject window;
    //Indicator
    public GameObject indicator;
    //Text component
    public TMP_Text dialogueText;
    //Dialogue list
    public List<string> dialogue;
    //Writting speed
    public float writtingSpeed;
    //Index on dialogue
    private int index;
    //Character index
    private int charIndex;
    //Started boolean
    private bool started;
    //Wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }


    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //Start Dialogue

    public void StartDialogue()
    {
        if (started)
            return;


        //Boolean to indicate that we have started
        started = true;
        //Show the window
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //Start with first dialogue
        GetDialogue(0);
        
    }

    private void GetDialogue(int i)
    {
        //start index at zero
        index = i;
        //Reset character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //Start writtnig
        StartCoroutine(Writting());
    }

    //End Dialogue
    public void EndDialogue()
    {
        //Started is disabled
        started = false;
        //Disable wait for next as well
        waitForNext = false;
        //Stop all IEnumerator
        StopAllCoroutines();
        //Hide the window
        ToggleWindow(false);
    }
    //Writting logic

    IEnumerator Writting()
    {
        yield return new WaitForSeconds(writtingSpeed);

        string currentDialogue = dialogue[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //Increase the character index
        charIndex++;
        //Make sure you have reached the end of the sentence
        if(charIndex < currentDialogue.Length)
        {
            //wait in seconds
        yield return new WaitForSeconds(writtingSpeed);
        //Restart the same process
        StartCoroutine(Writting());
        }
        else
        {
            //End this sentence and wait for the next one
            waitForNext = true;
        }
        
    }

    private void Update()
    {
        if (!started)
            return;
        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            //Check if we are in the scope of dialogues list
            if(index < dialogue.Count)
            {
                //if so fetch the next dialogue
                GetDialogue(index);
            }
            else
            {
                //If not, end the dialogue process
                ToggleIndicator(true);
                //End dialogue
                EndDialogue();
            }
        }
    }
}
