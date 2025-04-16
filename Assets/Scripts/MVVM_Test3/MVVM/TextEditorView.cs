using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using Debug = UnityEngine.Debug;
using TMPro;

namespace Assets.Scripts.MVVM_Test3.MVVM
{
    public class TextEditorView : MonoBehaviour
    {
        public TMP_InputField inputField;
        public TMP_Text highlightedText;
        public Color keywordColor;

        private TextEditorViewModel _viewModel;
        private Stopwatch stopwatch = new Stopwatch();
        public double updateTime;

        private void Start()
        {
            TextEditorModel model = new TextEditorModel();
            _viewModel = new TextEditorViewModel(model);
            _viewModel.KeywordColor = keywordColor;
            inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
            _viewModel.OnHighlightedTextChanged += UpdateHighlightedText;
        }

        private void OnInputFieldValueChanged(string text)
        {
            _viewModel.OnTextInputChanged(text);
        }

        public void UpdateHighlightedText(string highlightedTextString)
        {
            stopwatch.Reset();
            stopwatch.Start();
            highlightedText.text = highlightedTextString;
            stopwatch.Stop();
            updateTime = stopwatch.Elapsed.TotalMilliseconds;
            Debug.Log("UI Update Time (MVVM): " + updateTime + " ms");
        }

        private void OnDestroy()
        {
            _viewModel.OnHighlightedTextChanged -= UpdateHighlightedText;
            _viewModel.Unsubscribe();
        }
    }
}