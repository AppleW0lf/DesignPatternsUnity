using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MVVM_Test3.MVVM
{
    public class TextEditorViewModel
    {
        private readonly TextEditorModel _model;

        public event Action<string> OnHighlightedTextChanged;

        public Color KeywordColor { get; set; } = Color.blue;

        public TextEditorViewModel(TextEditorModel model)
        {
            _model = model;
            _model.OnTextChanged += HighlightText;
        }

        public void OnTextInputChanged(string newText)
        {
            _model.SetText(newText);
        }

        private void HighlightText(string text)
        {
            string highlightedText = text;
            foreach (string keyword in _model.Keywords)
            {
                string pattern = $@"\b{keyword}\b";
                highlightedText = Regex.Replace(highlightedText, pattern, $"<color=#{ColorUtility.ToHtmlStringRGB(KeywordColor)}>{keyword}</color>");
            }
            OnHighlightedTextChanged?.Invoke(highlightedText);
        }

        public void Unsubscribe()
        {
            _model.OnTextChanged -= HighlightText;
        }
    }
}