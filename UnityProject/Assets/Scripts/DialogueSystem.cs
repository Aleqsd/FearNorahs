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
		//Start exam
		//Question 1
        dialogueStory = new BinaryTree<Dialogue.Dialogue>
        {
			Root = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Qui dois-je contacter pour avoir un RDV avec Yven Rigollet ?", "Sandrine Dailey", "Sharon Boudy"))
        };
		//Answer 1 = mène à question 2
		dialogueStory.Root.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Quel doit être le premier reflèxe avant d’envoyer une question par mail à l’administration ?",
            "Passer par son délégué",
            "Lire le memento"));
		
		//Answer 2 = wrong answer
		dialogueStory.Root.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Non, je suis assez occupée comme ça ! Il faudra contacter Sandrine !", "", ""));

        ////////////////////////////////
		//Answer 1 = wrong answer
		dialogueStory.Root.Left.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("NON ! TOUJOURS lire le mémento !",
            "",
            ""));

		//Answer 2 = lead to the question 3
		dialogueStory.Root.Left.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Quel justificatif est recevable pour justifier une absence ?",
			"Obligation d’entreprise",
			"Certificat de mariage ou PACS"));

        ////////////////////////////////
		//Answer 1 = lead to the question 4
		dialogueStory.Root.Left.Right.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Si vous êtes en mobilité réduite, quel est le protocole lors d’une évacuation pendant un incendie.",
			"L’intervenant vous accompagne dans une salle sécurisée et va chercher de l’aide",
			"L’intervenant attend avec vous les secours, sans bouger"));

		//Answer 2 = wrong answer
		dialogueStory.Root.Left.Right.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("C’était l’obligation entreprise !",
            "",
            "")); 

		////////////////////////////////
		//Answer 1 = wrong answer
		dialogueStory.Root.Left.Right.Left.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Non ! L’intervenant patiente avec vous sans bouger, même dans le feu ! Mouahahaha !",
			"",
			""));

		//Answer 2 = lead to the question 5
		dialogueStory.Root.Left.Right.Left.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("En cas d’incendie, le point de rendez-vous se situe devant l’entrée du Super U, sur le parvis, à :",
			"7 mètres des façades",
			"10 mètres des façades")); 

		////////////////////////////////
		//Answer 1 = lead to the question 6
		dialogueStory.Root.Left.Right.Left.Right.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Quelle interdiction figure sur le memento, partie hygiène ?",
			"Interdiction de lécher une table",
			"Interdiction de marcher sur les murs"));

		//Answer 2 = wrong answer
		dialogueStory.Root.Left.Right.Left.Right.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("7 mètres ! Tout le monde sait ça !",
			"",
			""));
		
		////////////////////////////////
		//Answer 1 = wrong answer
		dialogueStory.Root.Left.Right.Left.Right.Left.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("C’était marcher sur les murs ! Si si, cherchez, elle y est.",
			"",
			""));

		//Answer 2 = lead to the question 7
		dialogueStory.Root.Left.Right.Left.Right.Left.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Dans quel cas doit-on faire un Duty Déjeuner ?",
			"En cas de non respect des règles d’hygiène",
			"En cas de non respect des horaires de déjeuner")); 

		////////////////////////////////
		//Answer 1 = lead to the question 8
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Quelle est l’adresse e-mail officielle du BSI ?",
			"bsi@ynovaix.com",
			"ynovaix.assistance@gmail.com"));

		//Answer 2 = wrong answer
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Non ! Lisez la dernière page du memento enfin ! Tout le monde sait ce qu’est un Duty Déjeuner !",
			"",
			"")); 

		////////////////////////////////
		//Answer 1 = wrong answer
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Left.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Lol, et non !",
			"",
			""));

		//Answer 2 = lead to the question 9
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Left.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Si je fais l’avance pour passer une certification diplômante, quelle démarche administrative dois-je faire pour être remboursé ?",
			"Faire une note de frais",
			"Fournir une attestation de réussite à Sandrine"));

		////////////////////////////////
		//Answer 1 = lead to the question 10
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Left.Right.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("D’après le mémento, lequel de ces vilains méfaits est puni d’un avertissement ?",
			"Porter des tongs",
			"Avoir des résultats insuffisants"));

		//Answer 2 = wrong answer
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Left.Right.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Eh non, c’était une note de frais, évidemment !",
			"",
			""));

		////////////////////////////////
		//Answer 1 = wrong answer
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Left.Right.Left.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Et non, c’était avoir des résultats insuffisants, fallait pas être nul ! Mouahahaha ! ",
			"",
			""));

		//Answer 2 = victoire
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Left.Right.Left.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Bravo, vous avez répondu à toutes les questions !",
			"",
			""));
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

				//lose
            }
            else
            {
                answer1Text.text = dialogueNode.Left.Value.Answer1;
                answer2Text.text = dialogueNode.Left.Value.Answer2;
                dialogueText.text = dialogueNode.Left.Value.DialogueText;
                dialogueNode = dialogueNode.Left;

                score += 1;
            }
            scoreText.text = "Score : " + score;
        }
        else
        {
            dialoguePanel.SetActive(false);
        }

    }
}
