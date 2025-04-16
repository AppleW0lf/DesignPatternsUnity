using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ECS.LeoECS
{
    using System.Diagnostics;
    using TMPro;
    using UnityEngine;
    using UnityEngine.Profiling;
    using UnityEngine.UI; // Add this line to use Text
    using Debug = UnityEngine.Debug;

    public class FPSCounter : MonoBehaviour
    {
        private class GCEventReport
        {
            public int gcCount;
            public double gcDurationMs;
            public float timeBetweenGC;
            public double gcAllocKB;
            public float avgFPS;
            public long peakAllocatedMB;
            public long peakMonoMB;
        }

        [Header("Settings")]
        [SerializeField] private float _longTermInterval = 30f;

        private DateTime _lastLogTime;
        private float _previousFrameTime;

        // GC Tracking
        private int _currentGCCount;

        private long _allocBeforeGC;

        private List<GCEventReport> _gcReports = new List<GCEventReport>();

        // Performance Tracking
        private int _totalFrames;

        private float _totalTime;
        private float _intervalTimer;
        private long _currentPeakAllocated;
        private long _currentPeakMono;

        private Queue<float> _fpsQueue = new Queue<float>(); // Store FPS values for averaging
        private float _fpsSum = 0f;
        private float _averageFPS = 0f;

        private void Start()
        {
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            _currentGCCount = GC.CollectionCount(0);
            _allocBeforeGC = Profiler.GetTotalAllocatedMemoryLong();
            _previousFrameTime = Time.deltaTime;  // Изменил на Time.deltaTime
            _lastLogTime = DateTime.Now;
        }

        private void Update()
        {
            UpdateGCTracking();
            UpdatePerformanceStats();
            UpdateFPSDisplay();
            UpdateLongTermStats();
        }

        private void UpdateFPSDisplay()
        {
            float currentFPS = 1.0f / Time.deltaTime;
        }

        private void UpdateGCTracking()
        {
            int newGCCount = GC.CollectionCount(0);
            float currentFrameTime = Time.deltaTime;
            float frameTime = currentFrameTime - _previousFrameTime;
            _previousFrameTime = currentFrameTime;
            if (newGCCount > _currentGCCount)
            {
                RecordGCEvent(newGCCount, frameTime);
                _currentGCCount = newGCCount;
            }
        }

        private void RecordGCEvent(int newCount, float durationTime)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime - _lastLogTime;
            _lastLogTime = currentTime;
            GCEventReport report = new GCEventReport
            {
                gcCount = newCount,
                gcDurationMs = durationTime,
                timeBetweenGC = (float)elapsedTime.TotalSeconds,
                gcAllocKB = (Profiler.GetTotalAllocatedMemoryLong() - _allocBeforeGC) / (1024.0 * 1024.0),
                avgFPS = _averageFPS,
                peakAllocatedMB = _currentPeakAllocated / (1024 * 1024),
                peakMonoMB = _currentPeakMono / (1024 * 1024)
            };

            _gcReports.Add(report);
            LogGCEvent(report);

            _lastLogTime = currentTime;
            _allocBeforeGC = Profiler.GetTotalAllocatedMemoryLong();
            _totalFrames = 0;
            _totalTime = 0f;
            _currentPeakAllocated = 0;
            _currentPeakMono = 0;
        }

        private void UpdatePerformanceStats()
        {
            _totalFrames++;
            _totalTime += Time.deltaTime;
            //_intervalTimer += Time.deltaTime;

            long allocated = Profiler.GetTotalAllocatedMemoryLong();
            long mono = Profiler.GetMonoUsedSizeLong();

            if (allocated > _currentPeakAllocated) _currentPeakAllocated = allocated;
            if (mono > _currentPeakMono) _currentPeakMono = mono;

            float currentFPS = 1.0f / Time.deltaTime; // Calculate FPS every frame
            _fpsSum += currentFPS;
            _fpsQueue.Enqueue(currentFPS);
        }

        private void UpdateLongTermStats()
        {
            _intervalTimer += Time.deltaTime;
            if (_intervalTimer >= _longTermInterval)
            {
                LogLongTermStats();
                _intervalTimer = 0f;
            }
            if (_fpsQueue.Count > (_longTermInterval / Time.deltaTime)) // Adjust queue size based on FixedUpdate frequency
            {
                _fpsSum -= _fpsQueue.Dequeue();
            }

            _averageFPS = _fpsSum / _fpsQueue.Count;
        }

        private void LogGCEvent(GCEventReport report)
        {
            string log = $"<color=green>GC Event #{report.gcCount}</color>\n" +
                         $"GC Duration: {report.gcDurationMs:F2}ms\n" +
                         $"Time Since Last GC: {report.timeBetweenGC:F2}s\n" +
                         $"GC Allocations: {report.gcAllocKB:F2} MB\n" +
                         $"Avg FPS: {report.avgFPS:F1}\n" +
                         $"Peak Allocated: {report.peakAllocatedMB} MB\n" +
                         $"Peak Mono: {report.peakMonoMB} MB";

            Debug.LogWarning(log);
        }

        private void LogLongTermStats()
        {
            //float avgFPS = _totalFrames / _longTermInterval;
            long allocatedMB = Profiler.GetTotalAllocatedMemoryLong() / (1024 * 1024);
            long monoMB = Profiler.GetMonoUsedSizeLong() / (1024 * 1024);

            string stats = $"<color=orange>30-Seconds Report:</color>\n" +
                          $"Avg FPS: {_averageFPS:F1}\n" +
                          $"Current Allocated: {allocatedMB} MB\n" +
                          $"Current Mono Heap: {monoMB} MB\n" +
                          $"Total GC Events: {_gcReports.Count}";

            Debug.LogWarning(stats);
        }

        private void OnDisable()
        {
            // Ensure queue is cleared when the script is disabled to prevent memory leaks
            _fpsQueue.Clear();
            _fpsSum = 0f;
            _averageFPS = 0f;
        }
    }
}