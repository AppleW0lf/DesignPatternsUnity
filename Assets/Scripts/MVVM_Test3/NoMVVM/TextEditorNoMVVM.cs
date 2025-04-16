using System.Diagnostics;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.MVVM_Test3.NoMVVM
{
    public class TextEditorNoMVVM : MonoBehaviour
    {
        public TMP_InputField inputField;
        public TMP_Text highlightedText;
        public Color keywordColor = Color.blue;
        public string[] keywords = { "if", "else", "for", "while" };

        private string currentText = "";
        private Stopwatch stopwatch = new Stopwatch();
        public double updateTime;

        private void Start()
        {
            inputField.onValueChanged.AddListener(OnTextChanged);
        }

        public void OnTextChanged(string text)
        {
            stopwatch.Reset();
            stopwatch.Start();

            currentText = text;
            string highlighted = HighlightKeywords(currentText);
            highlightedText.text = highlighted;

            stopwatch.Stop();
            updateTime = stopwatch.Elapsed.TotalMilliseconds;
            Debug.Log("UI Update Time (No MVVM): " + updateTime + " ms");
        }

        private string HighlightKeywords(string text)
        {
            string highlightedText = text;
            foreach (string keyword in keywords)
            {
                string pattern = $@"\b{keyword}\b"; // Регулярное выражение для поиска целых слов
                highlightedText = Regex.Replace(highlightedText, pattern, $"<color=#{ColorUtility.ToHtmlStringRGB(keywordColor)}>{keyword}</color>");
            }
            return highlightedText;
        }
    }
}