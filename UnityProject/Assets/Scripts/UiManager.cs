using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    private string charSelected = "man";

    public GameObject[] prefabs;
    public Material material;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                foreach (var prefab in prefabs)
                    prefab.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;
                    //prefab.GetComponentInChildren<SkinnedMeshRenderer>().material = material;
                Debug.Log("Mouse Down Hit the following object: " + hit.collider.name);
                hit.collider.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
                charSelected = hit.collider.name;
            }

        }
    }

    public void StartGame()
    {

        PlayerPrefs.SetInt("charSelected", charSelected == "grandma" ? 0 : charSelected == "grandpa" ? 1 : charSelected == "kid" ? 2 : 3);
        SceneManager.LoadScene("Game");
    }

    public void SelectCharacter(int charSelected)
    {
        Debug.Log("CharSelected" + charSelected);
        PlayerPrefs.SetInt("charSelected", charSelected);
    }
}
