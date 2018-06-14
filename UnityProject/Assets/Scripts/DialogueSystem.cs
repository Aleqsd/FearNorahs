using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BinaryTree;

public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem Instance { get; set; }
    public BinaryTree<Dialogue.Dialogue> dialogueStory;
    public GameObject dialoguePanel;
    public GameObject scorePanel;
	public GameObject brimstone;
	public GameObject smog;
	public GameObject lavaField;
	public GameObject plasma;
	public GameObject vulcore;
	public GameObject darkness;
	public GameObject firestorm;
	public GameObject dirtyFirestorm;
	public GameObject summon;

    public string npcName;

	Button answer1Button;
	Button answer2Button;
	Button answer3Button;
    Text dialogueText, nameText, answer1Text, answer2Text, answer3Text, scoreText;
    BinaryTreeNode<Dialogue.Dialogue> dialogueNode;
    int score = 0;
	string winText = "Bravo, vous avez répondu à toutes les questions !";
	string loseText = "Adieu ! Mouahahah !";

    // Use this for initialization
    void Awake () {
        StoryInitialisation();

		answer1Button = dialoguePanel.transform.Find("Answer1").GetComponent<Button>();
		answer2Button = dialoguePanel.transform.Find("Answer2").GetComponent<Button>();
		answer3Button = dialoguePanel.transform.Find("Answer3").GetComponent<Button>();
		answer3Button.gameObject.SetActive (false);
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        scoreText = scorePanel.GetComponent<Text>();
        answer1Text = answer1Button.GetComponentInChildren<Text>();
		answer2Text = answer2Button.GetComponentInChildren<Text>();
		answer3Text = answer3Button.GetComponentInChildren<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        dialogueNode = new BinaryTreeNode<Dialogue.Dialogue>();
        dialogueNode = dialogueStory.Root;

        answer1Text.text = dialogueStory.Root.Value.Answer1;
        answer2Text.text = dialogueStory.Root.Value.Answer2;
        dialogueText.text = dialogueStory.Root.Value.DialogueText;


        answer1Button.onClick.AddListener(delegate { ContinueDialogue(true); });
		answer2Button.onClick.AddListener(delegate { ContinueDialogue(false); });
		answer3Button.onClick.AddListener(delegate { Application.LoadLevel(Application.loadedLevel); });

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
		dialogueStory.Root.Left.Right.Left = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue("Quel est le protocole à suivre lors d’un incendie pour un étudiant en mobilité réduite ?",
			"L'intervenant va chercher les secours pendant qu'il attend",
			"L’intervenant attend avec lui les secours, sans bouger"));

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
		dialogueStory.Root.Left.Right.Left.Right.Left.Right.Left.Right.Left.Right = new BinaryTreeNode<Dialogue.Dialogue>(new Dialogue.Dialogue(winText,
			"",
			""));
    }

    public void AddNewDialogue(/*string[] dLines,*/ string npcName)
    {
		this.npcName = npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

	public void ContinueDialogue(bool choice) // Answer one : true (for left), answer two : false (for right)
    {        
        if (dialogueNode.Left != null) // If left is null, means that right is null too : no more dialog
        {
            
            if (!choice)
            {
                answer1Text.text = dialogueNode.Right.Value.Answer1;
                answer2Text.text = dialogueNode.Right.Value.Answer2;
                dialogueText.text = dialogueNode.Right.Value.DialogueText;
                dialogueNode = dialogueNode.Right;
            }
            else
            {
                answer1Text.text = dialogueNode.Left.Value.Answer1;
                answer2Text.text = dialogueNode.Left.Value.Answer2;
                dialogueText.text = dialogueNode.Left.Value.DialogueText;
                dialogueNode = dialogueNode.Left;
            }

			if (answer1Text.text == "" && answer2Text.text == "") {
				answer1Button.gameObject.SetActive (false);
				answer2Button.gameObject.SetActive (false);
				if (dialogueText.text == winText) {
					score++;
					scoreText.text = "Score : " + score;
					StartCoroutine (EndGame (true));
				} else {					
					StartCoroutine (EndGame (false));
				}
			}
			else
			{
				score++;
			}

            scoreText.text = "Score : " + score;

			if (score == 1)
			{
				Instantiate(smog, new Vector3(41.668f, 2.375f, -11.598f), new Quaternion(0, 0, 0, 0));
			}

			if (score == 2)
			{
				Instantiate(smog, new Vector3(41.668f, 2.375f, -12.73f), new Quaternion(0, 0, 0, 0));
			}

			if (score == 3)
			{
				Instantiate(lavaField, new Vector3(48.7796f, 1.04f, -8.39f), new Quaternion(0, 0, 0, 0));
				Instantiate(lavaField, new Vector3(48.7796f, 1.04f, -12.78f), new Quaternion(0, 0, 0, 0));
				Instantiate(lavaField, new Vector3(48.7796f, 1.04f, -16.84f), new Quaternion(0, 0, 0, 0));
				Instantiate(lavaField, new Vector3(48.7796f, 1.04f, -20.61f), new Quaternion(0, 0, 0, 0));				
			}

			if (score == 4)
			{
				Instantiate(plasma, new Vector3(39.37f, 0.21f, -15.72783f), new Quaternion(0, 0, 0, 0));
			}

			if (score == 5)
			{
				Instantiate(vulcore, new Vector3(54.18f, 3f, -6.79f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(54.18f, 3f, -10.38f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(54.18f, 3f, -14.43f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(54.18f, 3f, -18.01f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(54.18f, 3f, -21.86f), new Quaternion(0, 0, 0, 0));
			}
			if (score == 6)
			{
				Instantiate(darkness, new Vector3(40.42f, -2.109f, -13.24f), new Quaternion(0, 0, 0, 0));
			}

			if (score == 7)
			{
				Instantiate(vulcore, new Vector3(51.1f, 3f, -24.15f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(47.18f, 3f, -24.15f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(43.55f, 3f, -24.15f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(40.25f, 3f, -24.15f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(36.65f, 3f, -24.15f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(33f, 3f, -24.15f), new Quaternion(0, 0, 0, 0));
				Instantiate(vulcore, new Vector3(29.11f, 3f, -24.15f), new Quaternion(0, 0, 0, 0));
			}

			if (score == 8)
			{
				Instantiate(firestorm, new Vector3(48.97f, 2f, -7.73f), new Quaternion(0, 0, 0, 0));
				Instantiate(firestorm, new Vector3(48.97f, 2f, -18.97f), new Quaternion(0, 0, 0, 0));
			}

			if (score == 9)
			{
				Instantiate(dirtyFirestorm, new Vector3(47.86f, 0.88f, -13.47f), new Quaternion(0, 0, 0, 0));
			}
        }
        else
        {
            dialoguePanel.SetActive(false);
        }

    }

	IEnumerator EndGame(bool win)
	{
		Debug.Log("eng game");
		yield return new WaitForSeconds(3);
		if (win) {
			scoreText.text = "Vous avez réussi !";
			answer3Text.text = "Recommencer";
			answer3Button.gameObject.SetActive (true);	
			Instantiate(summon, new Vector3(38.82f, 3.97f, -8.3f), new Quaternion(0, 0, 0, 0));		
		}
		else {
			scoreText.text = "Vous avez échoué avec " + score + " points !";
			dialogueText.text = loseText;
			answer3Text.text = "Recommencer";
			answer3Button.gameObject.SetActive (true);
			Instantiate(brimstone, new Vector3(36, 1, -12), new Quaternion(0, 0, 0, 0));
			Instantiate(brimstone, new Vector3(34, 1, -12), new Quaternion(0, 0, 0, 0));
			Instantiate(brimstone, new Vector3(38, 1, -12), new Quaternion(0, 0, 0, 0));
			Instantiate(brimstone, new Vector3(36, 1, -10), new Quaternion(0, 0, 0, 0));
			Instantiate(brimstone, new Vector3(34, 1, -10), new Quaternion(0, 0, 0, 0));
			Instantiate(brimstone, new Vector3(38, 1, -10), new Quaternion(0, 0, 0, 0));
		}
	}
}
