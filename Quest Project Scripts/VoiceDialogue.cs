using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VoiceDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; //Where our dialogue is being types to
    public string[] sentences;          //Holds the dialogue
    private int sentenceIndex;          //Index at you are at in the dialogue array
    public AudioSource[] voices;        //Array of voices
    private int voiceIndex = 0;         //Index you are at in the voices array
    public float typingSpeed;           //How long to wait after typing a letter
    public GameObject continueButton;   //To circumvent overlapping text
    public GameObject acceptButton;
    public GameObject declineButton;
    public GameObject interactPrompt;   //Used to show that you can interact with an NPC
    public GameObject target, player;   //Objects to be passed in to calculate distance between the player and a certain NPC
    bool quest_Active;
    public GameObject questDestination;

   
    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the audio source
        //voices = RandyOrton;
    }

    // Update is called once per frame
    void Update()
    {
        //To check if current sentence has been fully displayed
        if (textDisplay.text == sentences[sentenceIndex])
        {
            continueButton.SetActive(true); //Show the continue button

            if (Input.GetKey(KeyCode.Q)) //If the player presses Q
                NextSentence(); //Go to the next sentence in the array
        }
       
        //If the player is within range, and the target in question is not talking
        if (CalculateDistance(target, player) && target.tag == "NotTalking")
        {
            target.tag = "Talking"; //Set their tag to talking 
            StartCoroutine(Type()); //Start up the dialogue
        }
            
    }

    
        //Function to calculate the distance between the player character and a specific NPC
        private bool CalculateDistance(GameObject object1, GameObject object2)
        {
            //If the distance between the two is less than 3
            if (Vector3.Distance(player.transform.position, target.transform.position) < 3)
            {
                if (target.tag == "Talking") //Check if the NPC is talking
                    interactPrompt.SetActive(false); //If it is, hide the interact prompt
                else //If it's not talking
                    interactPrompt.SetActive(true); //Prompt for interaction


                if (Input.GetKeyDown(KeyCode.E)) //Press E to interact
                {
                    interactPrompt.SetActive(false); //Hide the interaction prompt
                    return true;
                }
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
               
                   
                    
                
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else //If you are not in range of the object
            {
                interactPrompt.SetActive(false); //Hide the interaction prompt
                return false;
            }
            return false;
        }

        //Make a coroutine to show dialogue 
        IEnumerator Type()
        {
            //Play the first voice clip in the array
            PlayVO();

            //Foreach loop to type a letter in the string crisply
            foreach (char letter in sentences[sentenceIndex].ToCharArray())
            {
                textDisplay.text += letter;
                //Waits for this amount of seconds
                yield return new WaitForSeconds(typingSpeed);
            }


        }

        //Will play all the dialog in the array of voice lines
        private void PlayVO()
        {
            while (voiceIndex < voices.Length) //Count until the end of the voices array
            {
                voices[voiceIndex].Play(); //Play the voice at that index
                voiceIndex++; //Increment one up the index
                break;
            }
        }

        public void NextSentence()
        {
            //Text is going, hide continue button
            continueButton.SetActive(false);

            //Operation: Circumvent the overlapping audio problem
            for (int x = 0; x < voices.Length; x++)
            {
                if (voices[x].isPlaying) //If there is
                    voices[x].Stop(); //Disable it
            }

            //Make sure dialogue is finished typing
            if (sentenceIndex < sentences.Length - 1) //Minus one because arrays start at 0
            {
                sentenceIndex++; //Go up one in array
                textDisplay.text = ""; //Reset textDisplay
                StartCoroutine(Type());
            }
            else if (sentenceIndex == sentences.Length - 1) //If the index is at the end of the array
            {
                textDisplay.text = ""; //Clear the text
                sentenceIndex = 0; //Reset array indices
                voiceIndex = 0;
                target.tag = "NotTalking"; //Reset the target back to not talking

        }
            else
            {
                //Reset text when dialogue is complete
                textDisplay.text = "";
                continueButton.SetActive(false); //Hide continue button
            }


        }

}



