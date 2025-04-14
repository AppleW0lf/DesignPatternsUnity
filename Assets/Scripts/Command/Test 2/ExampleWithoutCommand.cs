using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ExampleWithoutCommand : MonoBehaviour
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

    public Stack<(object, System.Action)> moveHistory = new Stack<(object, System.Action)>();

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
        Vector3 previousPosition = pivotTransform.position;
        pivotTransform.position += Vector3.right * stepDistance;
        moveHistory.Push((previousPosition, () => pivotTransform.position = previousPosition));
    }

    private void StepBackward()
    {
        Vector3 previousPosition = pivotTransform.position;
        pivotTransform.position += Vector3.left * stepDistance;
        moveHistory.Push((previousPosition, () => pivotTransform.position = previousPosition));
    }

    private void StepDiagonalUpRight()
    {
        Vector3 previousPosition = pivotTransform.position;
        Vector3 diagonalDirection = new Vector3(1f, 1f, 0).normalized;
        pivotTransform.position += diagonalDirection * stepDistance;
        moveHistory.Push((previousPosition, () => pivotTransform.position = previousPosition));
    }

    private void StepDiagonalDownLeft()
    {
        Vector3 previousPosition = pivotTransform.position;
        Vector3 diagonalDirection = new Vector3(-1f, -1f, 0).normalized;
        pivotTransform.position += diagonalDirection * stepDistance;
        moveHistory.Push((previousPosition, () => pivotTransform.position = previousPosition));
    }

    private void Jump()
    {
        Vector3 previousPosition = pivotTransform.position;
        pivotTransform.position += Vector3.up * jumpHeight;
        moveHistory.Push((previousPosition, () => pivotTransform.position = previousPosition));
    }

    private void RotateClockwise()
    {
        Quaternion previousRotation = pivotTransform.rotation;
        pivotTransform.Rotate(Vector3.forward, rotationAngle);
        moveHistory.Push((previousRotation, () => pivotTransform.rotation = (Quaternion)previousRotation));
    }

    public void UndoLastMove()
    {
        if (moveHistory.Count > 0)
        {
            (object previousState, System.Action undoAction) = moveHistory.Pop();
            undoAction();
        }
        else
        {
            Debug.LogWarning("No moves to undo!");
        }
    }
}