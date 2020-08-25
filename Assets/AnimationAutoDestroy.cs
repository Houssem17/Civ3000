 using UnityEngine;
 using System.Collections;
 
 public class AnimationAutoDestroy : MonoBehaviour {
     public float delay = 0f;
 
     // Use this for initialization
     void Start () {
         Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
     }
 }