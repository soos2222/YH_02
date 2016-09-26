using UnityEngine;
using System.Collections;

public class YH_moving : MonoBehaviour {
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (vertical > 0 && horizontal > 0) //오른쪽 점프
        {
            animator.SetInteger("direction", 1);
        }
        else if(vertical>0&&horizontal<0)//왼쪽 점프
        {
            animator.SetInteger("direction", 3);
        }
        else if(horizontal>0)//오른쪽걷기
        {
            animator.SetInteger("direction", 0);
        }
        else if(horizontal<0)//왼쪽걷기
        {
            animator.SetInteger("direction", 2);
        }

	}
}
