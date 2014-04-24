using UnityEngine;
using System.Collections;
/*
 * 
 * https://docs.unity3d.com/Documentation/Manual/DrawCallBatching.html
 * 
 * Other batching tips
Currently, only Mesh Renderers and Particle Systems are batched. This means that skinned meshes, cloth, trail renderers and other types of rendering components are not batched.
*
**/

[AddComponentMenu("Sprite/Combine Children")]
public class CombineSpriteChildren : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
		//StaticBatchingUtility.Combine (gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
