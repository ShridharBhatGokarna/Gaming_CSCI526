﻿using System.Collections;
using UnityEngine;

class GridMove : MonoBehaviour
{
    private float moveSpeed = 1.5f;
    private float gridSize = 1f;
    private enum Orientation
    {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Horizontal;
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = false;
    private Vector2 input;
    private bool isMoving = false;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float t;
    private float factor;

    public void Update()
    {
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (!allowDiagonals)
            {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else
                {
                    input.x = 0;
                }
            }

            if (input != Vector2.zero)
            {
                StartCoroutine(move(transform));
            }
        }
    }

    public IEnumerator move(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector2(startPosition.x + (System.Math.Sign(input.x) * gridSize) ,
                startPosition.y+ (System.Math.Sign(input.y) * gridSize) );
        }
        else
        {
            endPosition = new Vector2(startPosition.x + (System.Math.Sign(input.x) * gridSize) ,
               startPosition.y + (System.Math.Sign(input.y) * gridSize) );
        }

        if (endPosition.y > (gridSize * 6) || endPosition.x >(gridSize*6))
        {
            endPosition = startPosition;
        }
        if (endPosition.y <=0 || endPosition.x <=0)
        {
            endPosition = startPosition;
        }

        if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0)
        {
            factor = 0.7071f;
        }
        else
        {
            factor = 1f;
        }

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
}