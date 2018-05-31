using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BinaryTree;

public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance { get; set; }
    //public List<string> dialogueLines = new List<string>();
    public BinaryTree<Dialogue.Dialogue> dialogueStory;
    public GameObject dialoguePanel;
    public GameObject scorePanel;
    public string npcName;

    Button answer1Button;
    Button answer2Button;
    Text dialogueText, nameText, answer1Text, answer2Text, scoreText;
    //int dialogueIndex;
    BinaryTreeNode<Dialogue.Dialogue> dialogueNode;
    int score = 0;

    // Use this for initialization
    void Awake () {
        StoryInitialisation();

        answer1Button = dialoguePanel.transform.Find("Answer1").GetComponent<Button>();
        answer2Button = dialoguePanel.transform.Find("Answer2").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        scoreText = scorePanel.GetComponent<Text>();
        answer1Text = answer1Button.GetComponentInChildren<Text>();
        answer2Text = answer2Button.GetComponentInChildren<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        dialogueNode = new BinaryTreeNode<Dialogue.Dialogue>();
        dialogueNode = dialogueStory.Root;

        answer1Text.text = dialogueStory.Root.Value.Answer1;
        answer2Text.text = dialogueStory.Root.Value.Answer2;
        dialogueText.text = dialogueStory.Root.Value.DialogueText;


        answer1Button.onClick.AddListener(delegate { ContinueDialogue(true); });
        answer2Button.onClick.AddListener(delegate { ContinueDialogue(false); });

        dialoguePanel.SetActive(false);


		if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}

    private void StoryInitialisation()
    {
        dialogueStory = new BinaryTree<Dialogue.Dialogue>
        {
            Root = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Bonjour", "Bonjour", "Multiprise"))
        };
        dialogueStory.Root.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Que voulez-vous ?",
            "Une multiprise s'il-vous-plait",
            "Multiprise"));
        dialogueStory.Root.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Et bonjour c'est pour les chiens ?", "Excusez-moi ...", "TG"));

        ////////////////////////////////

        dialogueStory.Root.Left.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Voila",
            "Merci",
            "..."));
        dialogueStory.Root.Left.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("S'il-vous-plait ?",
            "Excusez-moi, S'il-vous-plait",
            "Nop"));

        ////////////////////////////////

        dialogueStory.Root.Right.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("C'est rien, voila",
            "Merci",
            "..."));
        dialogueStory.Root.Right.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Avertissement !!",
            "Excusez-moi",
            "Allllllerr")); 

        ////////////////////////////////
    }

    public void AddNewDialogue(/*string[] dLines,*/ string npcName)
    {
        /*dialogueIndex = 0;
        dialogueLines = new List<string>(dLines.Length);
        dialogueLines.AddRange(dLines);*/
        
        this.npcName = npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        //dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue(bool choice) // Answer one : false, answer two : true
    {
        /*
        if (dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
            if (choice) answer1Button.GetComponentInChildren<Text>().text = "yeaa"; else answer2Button.GetComponentInChildren<Text>().text = "yeaa";
        }
        else
        {
            dialoguePanel.SetActive(false);
        }*/
        
        if (dialogueNode.Left != null) // If left is null, means that right is null too : no more dialog
        {
            
            if (!choice)
            {
                answer1Text.text = dialogueNode.Right.Value.Answer1;
                answer2Text.text = dialogueNode.Right.Value.Answer2;
                dialogueText.text = dialogueNode.Right.Value.DialogueText;
                dialogueNode = dialogueNode.Right;

                if(score > 9) // Avoid going under score 0
                    score -= 10;
            }
            else
            {
                answer1Text.text = dialogueNode.Left.Value.Answer1;
                answer2Text.text = dialogueNode.Left.Value.Answer2;
                dialogueText.text = dialogueNode.Left.Value.DialogueText;
                dialogueNode = dialogueNode.Left;

                score += 10;
            }
            scoreText.text = "Score : " + score;
        }
        else
        {
            dialoguePanel.SetActive(false);
        }

    }
}
