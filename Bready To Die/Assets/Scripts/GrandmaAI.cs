using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaAI : MonoBehaviour
{
    public Animator grandmaAnimator;
    public float rotationRate = 50;
    public float breadThrowRate = 2;

    public GameObject breadSpawnPoint;

    public GameObject breadPrefab;
    public Vector2 breadThrowForce;

    float timeSinceLastThrow;

    public GameObject[] nodes;
    public float moveSpeed = 3f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!grandmaAnimator.GetCurrentAnimatorStateInfo(0).IsName("toss"))
        {
            timeSinceLastThrow += Time.deltaTime;
            if (timeSinceLastThrow >= breadThrowRate)
            {
                timeSinceLastThrow = 0;
                ThrowBreadAnim();
            }
        }
        else
        {
            timeSinceLastThrow = 0;
        }

        transform.Rotate(Vector3.up, rotationRate * Time.deltaTime);

    }


    private void ThrowBreadAnim()
    {
        grandmaAnimator.SetTrigger("doThrow");
        if (breadThrowRate < 1)
        {
            grandmaAnimator.speed = 1/breadThrowRate;
        }
    }

    public void SpawnBread()
    {
        GameObject newBread = Instantiate(breadPrefab, breadSpawnPoint.transform.position, Quaternion.identity);
        newBread.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up).normalized * Random.Range(breadThrowForce.x, breadThrowForce.y), ForceMode.Impulse);
    }

}
