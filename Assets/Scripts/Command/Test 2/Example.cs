using Assets.Scripts.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Command
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private Button btnStepForward;
        [SerializeField] private Button btnStepBackward;
        [SerializeField] private Button btnStepDiagonalUpRight;
        [SerializeField] private Button btnStepDiagonalDownLeft;
        [SerializeField] private Button btnJump;
        [SerializeField] private Button btnRotateClockwise;
        [SerializeField] private Button btnUndo;
        [SerializeField] private Transform pivotTransform;
        [SerializeField] public float stepDistance = 1f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private float rotationAngle = 45f;

        public List<MoveCommand> moveJournal = new List<MoveCommand>();

        private void OnEnable()
        {
            btnStepForward.onClick.AddListener(StepForward);
            btnStepBackward.onClick.AddListener(StepBackward);
            btnStepDiagonalUpRight.onClick.AddListener(StepDiagonalUpRight);
            btnStepDiagonalDownLeft.onClick.AddListener(StepDiagonalDownLeft);
            btnJump.onClick.AddListener(Jump);
            btnRotateClockwise.onClick.AddListener(RotateClockwise);
            btnUndo.onClick.AddListener(UndoLastMove);
        }

        public void StepForward()
        {
            var move = new MoveCommandImpl(pivotTransform, Vector3.right, stepDistance);
            ExecuteMove(move);
        }

        private void StepBackward()
        {
            var move = new MoveCommandImpl(pivotTransform, Vector3.left, stepDistance);
            ExecuteMove(move);
        }

        private void StepDiagonalUpRight()
        {
            Vector3 diagonalDirection = new Vector3(1f, 1f, 0).normalized;
            var move = new MoveCommandImpl(pivotTransform, diagonalDirection, stepDistance);
            ExecuteMove(move);
        }

        private void StepDiagonalDownLeft()
        {
            Vector3 diagonalDirection = new Vector3(-1f, -1f, 0).normalized;
            var move = new MoveCommandImpl(pivotTransform, diagonalDirection, stepDistance);
            ExecuteMove(move);
        }

        private void Jump()
        {
            var jumpCommand = new JumpCommand(pivotTransform, jumpHeight);
            ExecuteMove(jumpCommand);
        }

        private void RotateClockwise()
        {
            var rotateCommand = new RotateCommand(pivotTransform, rotationAngle);
            ExecuteMove(rotateCommand);
        }

        private void ExecuteMove(MoveCommand move)
        {
            move.Execute();
            moveJournal.Add(move);
        }

        public void UndoLastMove()
        {
            if (moveJournal.Count > 0)
            {
                var lastMove = moveJournal.Last();
                moveJournal.Remove(lastMove);
                lastMove.Undo();
            }
            else
            {
                Debug.LogWarning("No moves to undo!");
            }
        }
    }
}