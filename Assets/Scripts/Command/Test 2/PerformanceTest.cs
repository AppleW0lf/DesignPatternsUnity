using Assets.Scripts.Command;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PerformanceTest2 : MonoBehaviour
{
    public int numberOfIterations = 10000;
    public Example controllerWithCommand;
    public ExampleWithoutCommand controllerWithoutCommand;
    public Transform testObjectWithCommand;
    public Transform testObjectWithoutCommand;

    private Vector3 initialPosition;

    private void Start()
    {
        if (controllerWithCommand == null || controllerWithoutCommand == null || testObjectWithCommand == null || testObjectWithoutCommand == null)
        {
            Debug.LogError("Please assign the controllers and test objects in the Inspector!");
            return;
        }

        initialPosition = testObjectWithCommand.position; // Assuming both objects start at the same place.

        TestCommandPattern();
        //TestNoCommandPattern();
    }

    private void ResetPositions()
    {
        // Reset objects to their starting position before each test.
        testObjectWithCommand.position = initialPosition;
        testObjectWithoutCommand.position = initialPosition;

        // Clear move history. A proper reset would ideally also reset rotation.
        controllerWithCommand.moveJournal.Clear(); // Clear Command move history (Reflection или public поле)
        controllerWithoutCommand.moveHistory.Clear(); // Clear No Command move history  (Reflection или public поле)
    }

    private void TestCommandPattern()
    {
        ResetPositions();  // Reset before each test

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < numberOfIterations; i++)
        {
            // Directly call functions that execute the movement
            StepForwardCommand(controllerWithCommand, testObjectWithCommand);
            UndoLastMoveCommand(controllerWithCommand, testObjectWithCommand);
        }
        StepForwardCommand(controllerWithCommand, testObjectWithCommand);
        stopwatch.Stop();
        Debug.Log($"Command Pattern: {stopwatch.ElapsedMilliseconds} ms for {numberOfIterations} iterations");
    }

    private void TestNoCommandPattern()
    {
        ResetPositions();  // Reset before each test

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < numberOfIterations; i++)
        {
            StepForwardNoCommand(controllerWithoutCommand, testObjectWithoutCommand);
            UndoLastMoveNoCommand(controllerWithoutCommand, testObjectWithoutCommand);
        }
        StepForwardNoCommand(controllerWithoutCommand, testObjectWithoutCommand);
        stopwatch.Stop();
        Debug.Log($"No Command Pattern: {stopwatch.ElapsedMilliseconds} ms for {numberOfIterations} iterations");
    }

    // --- Helper functions to move objects directly without UI ---

    private void StepForwardCommand(Example controller, Transform obj)
    {
        // Implement logic to move forward using Command pattern

        var move = new MoveCommandImpl(obj, Vector3.right, controller.stepDistance); // Use public stepDistance from controller
        move.Execute();
        controller.moveJournal.Add(move);  //add to the command history
    }

    private void UndoLastMoveCommand(Example controller, Transform obj)
    {
        if (controller.moveJournal.Count > 0)
        {
            var lastMove = controller.moveJournal.Last();
            controller.moveJournal.Remove(lastMove);
            lastMove.Undo();
        }
    }

    private void StepForwardNoCommand(ExampleWithoutCommand controller, Transform obj)
    {
        // Implement logic to move forward WITHOUT Command pattern
        Vector3 previousPosition = obj.position;
        obj.position += Vector3.right * controller.stepDistance; // Use public stepDistance from controller

        controller.moveHistory.Push((previousPosition, () => obj.position = previousPosition));
    }

    private void UndoLastMoveNoCommand(ExampleWithoutCommand controller, Transform obj)
    {
        if (controller.moveHistory.Count > 0)
        {
            (object previousState, System.Action undoAction) = controller.moveHistory.Pop();
            undoAction();
        }
    }
}