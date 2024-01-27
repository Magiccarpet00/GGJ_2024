using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private RightSide right;
    [SerializeField] private LeftSide left;

	public int direction;

    // Start is called before the first frame update
    void Start()
    {
		left.OnLeft += Left_OnLeft;
		right.OnRight += Right_OnRight;
    }

	private void Right_OnRight(int obj)
	{
		direction = obj;
	}

	private void Left_OnLeft(int obj)
	{
		direction = obj;
	}
}
