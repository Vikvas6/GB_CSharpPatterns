using System;
using UnityEngine.UI;


namespace Asteroids.MessageBroker
{
    public class ScreenMessagesConsumer : IConsumer
    {
        private readonly Text _text;

        public ScreenMessagesConsumer(Text text)
        {
            _text = text;
        }

        public void ConsumeMessage(string message)
        {
            string[] currentTextLines = _text.text.Split('\n');
            _text.text = "";
            for (int i = Math.Max(0, currentTextLines.Length - 7); i < currentTextLines.Length; i++)
            {
                _text.text += currentTextLines[i] + "\n";
            }

            _text.text += message;
        }
    }
}
