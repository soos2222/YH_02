using UnityEngine;
using System.Collections;


public class moveObj : MonoBehaviour
{
    float touchtime = 0;
    float posX = 0;
    float preX = 0;
    int touched = 0; //0이면 터치 안함, 1이면 왼쪽에서, 2면 오른쪽에서
    int movex = 0;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (touched == 0)
        {
            preX = transform.position.x;
            touchtime = 0;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (touched == 0)
        {
            if (other.transform.tag == "Yeti")
            {
                touchtime += Time.deltaTime;

                if (touchtime > 0.5)
                {
                    if (other.transform.position.x < transform.position.x)  //예티가 박스보다 왼쪽에 있을 때
                        touched = 1;
                    else
                        touched = 2;
                }
                else
                    touched = 0;
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        touchtime = 0;
    }

    void Update()
    {
        if (touched == 0)
            movex = 0;
        if (touched == 1)
            movex = 1;
        if (touched == 2)
            movex = -1;

        posX = Mathf.Lerp(transform.position.x, transform.position.x + movex, 5 * Time.deltaTime);
        transform.position = new Vector3(posX, transform.position.y, 0);

        if (transform.position.x-preX > 1 || transform.position.x-preX < -1)
            touched = 0;

    }
}
