using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesFalling : MonoBehaviour
{
    [SerializeField]
    protected Transform[] cubesToAnimate;
    [SerializeField]
    protected float fallingSpeed = 10;
    [SerializeField]
    protected float verticallOffset;
    [SerializeField]
    protected float zoneWidth;
    [SerializeField]
    protected float zoneHeight;

    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(zoneWidth, zoneHeight));

        return;
    }

    protected void Update()
    {
        //AnimateFallingCubes();
        ResetPosition();

        return;
    }

    protected void AnimateFallingCubes()
    {
        foreach(Transform cube in cubesToAnimate)
        {
            if(cube.position.y > transform.position.y - (zoneHeight/2 - verticallOffset))
            {
                Vector3 newPosition = Vector3.zero;
                newPosition.x = cube.position.x;
                newPosition.y = Mathf.Lerp(
                    cube.position.y, 
                    transform.position.y - zoneHeight / 2, 
                    fallingSpeed
                    );
                Debug.Log(Mathf.Abs((transform.position.y - cube.position.y) / fallingSpeed));
                cube.position = newPosition;
            }

            else if(cube.position.y < transform.position.y - (zoneHeight / 2 - verticallOffset))
                cube.position = new Vector3(cube.position.x, transform.position.y + zoneHeight / 2, 0);
        }

        return;
    }

    protected void ResetPosition()
    {
        foreach (Transform cube in cubesToAnimate)
        {
            if (cube.position.y < transform.position.y - (zoneHeight / 2 - verticallOffset))
            {
                cube.position = new Vector3(cube.position.x, transform.position.y + zoneHeight / 2, 0);
                cube.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

        }

        return;
    }
}
