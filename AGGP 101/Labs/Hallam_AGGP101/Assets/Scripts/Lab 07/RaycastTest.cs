/* Notes 
- Found that if the HitIcon object has a collider the 
  HitIcon object will move from the farthest wall the ray touches to the casting object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
	public GameObject ObjectRay;
	public GameObject HitIcon;
	public bool useObjectRay = true;

	public float rayDrawDistance = 50;
	public float rayCastDistance = 50;

	private void Update()
	{
		Ray directionRay = new Ray(gameObject.transform.position, gameObject.transform.forward);

		rayDrawDistance = rayCastDistance;

		RaycastHit hit;

		bool foundhit = Physics.Raycast(directionRay, out hit, rayCastDistance);
		if (foundhit)
		{
			rayDrawDistance = hit.distance;	//If there is a hit, set the draw distance of the ray to the contact point.
			Debug.Log("Found: " + hit.collider.gameObject.name);
			HitIcon.transform.position = hit.point; //When there is a hit, place object at contact point
		}
		else
		{
			HitIcon.transform.position = new Vector3(0, -10, 0); //Move to hidden position when not in use
		}
	}
}
