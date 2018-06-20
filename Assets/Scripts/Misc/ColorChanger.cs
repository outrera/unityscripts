using UnityEngine;

public class ColorChanger : MonoBehaviour
{
	public Color color1 = Color.blue;
	public Color color2 = Color.red;
	public int duration;
	public bool loop = false;

	private Color lerpedColor = Color.white;
    void Update() {
        if (loop) {
			lerpedColor = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, duration));
			Renderer rend = GetComponent<Renderer>();

        	//Set the main Color of the Material to green
        	//rend.material.shader = Shader.Find("_Color");

        	rend.materials[0].SetColor("_Color", lerpedColor);
			int materialCount = rend.materials.Length;
			print(materialCount.ToString());
		}
		
    }

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player") && !loop) {
			Renderer rend = GetComponent<Renderer>();
	        rend.materials[0].SetColor("_Color", color1);
		}
	}
}
