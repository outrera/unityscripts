using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<string> inventory = new List<string>();
	private int location;
	private string foundItem;
	private string neededItem;


	// Use this for initialization
	void Start () {
		inventory.Add("Bob");
		inventory.Add("Bobby");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void AddItem(string item)
	{
		inventory.Add(item);
	}

	bool CheckInventory(string item)
	{
		return inventory.Contains(item);
	}

	void RemoveItem (string item)
	{
		location = inventory.LastIndexOf(item);
		inventory.RemoveAt(location);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ( "Item"))
		{
			foundItem = other.GetComponent<FoundItem>().item;
			//foundItem = other.ToString();
			AddItem (foundItem);
			other.gameObject.SetActive(false);
		}
		if (other.gameObject.CompareTag ( "Locked"))
		{
			neededItem = other.GetComponent<RequiredItem>().item;
			if (CheckInventory(neededItem))
			{
				RemoveItem(neededItem);
				other.gameObject.SetActive(false);
			}
			else
			{
				print (foundItem);
			}

			//AddItem (foundItem);
		}

	}
}
