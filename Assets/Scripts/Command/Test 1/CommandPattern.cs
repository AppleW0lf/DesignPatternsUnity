using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Интерфейс команды
public interface ICommand
{
    void Execute();
}

// Конкретная команда
public class MoveCommand : ICommand
{
    private Transform _target;
    private Vector2 _direction;

    public MoveCommand(Transform target, Vector2 direction)
    {
        _target = target;
        _direction = direction;
    }

    public void Execute()
    {
        _target.position += new Vector3(
            _direction.x,
            _direction.y,
            0) * Time.deltaTime;
    }
}

public class CommandPattern : MonoBehaviour
{
    public Transform objectToMove;
    public int iterations = 100000;

    private List<ICommand> _commands = new List<ICommand>();

    private void Start()
    {
        var stopwatch = Stopwatch.StartNew();

        // Создание команд
        for (int i = 0; i < iterations; i++)
        {
            _commands.Add(new MoveCommand(objectToMove, Vector2.right));
        }

        // Выполнение команд
        foreach (var command in _commands)
        {
            command.Execute();
        }

        stopwatch.Stop();
        UnityEngine.Debug.Log($"Command pattern time: {stopwatch.ElapsedMilliseconds} ms");
    }
}