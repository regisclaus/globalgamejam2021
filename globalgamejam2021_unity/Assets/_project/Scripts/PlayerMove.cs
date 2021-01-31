using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float deltaMove = 3f;
    [SerializeField] private float timeMove = 0.5f;
    public Line line = Line.MID;

    private void OnMove(InputValue input) {
        if(!DOTween.IsTweening(this.transform)) {
            Vector2 inputVec = input.Get<Vector2>();
            if(inputVec.y > 0)
            {
                switch(line) {
                    case Line.MID:
                        line = Line.TOP;
                        UpLine();
                        break;
                    case Line.BOT:
                        line = Line.MID;
                        UpLine();
                        break;
                }
            }
            else if(inputVec.y < 0)
            {
                switch(line) {
                    case Line.MID:
                        line = Line.BOT;
                        DownLine();
                        break;
                    case Line.TOP:
                        line = Line.MID;
                        DownLine();
                        break;
                }
            }
        }

       
    }

    private void DownLine()
    {
        transform.DOLocalMoveX(transform.position.x + deltaMove, timeMove);
    }

    private void UpLine()
    {
        transform.DOLocalMoveX(transform.position.x - deltaMove, timeMove);
    }
}

public enum Line {
    TOP,
    MID,
    BOT
}
