using System.Collections.Generic;
using Asteroids.Interpreter;
using UnityEngine;


namespace Asteroids.Command
{
    public class UserInterface
    {
        private readonly InterpreterWindow _interpreterWindow;
        private readonly InfoWindow _infoWindow;
        private readonly Stack<StateUI> _stateUI = new Stack<StateUI>();
        private IBaseUI _currentWindow;

        public UserInterface(InterpreterWindow interpreterWindow, InfoWindow infoWindow)
        {
            _interpreterWindow = interpreterWindow;
            _interpreterWindow.Cancel();
            _infoWindow = infoWindow;
            _infoWindow.Cancel();
        }

        public void Execute(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }

            switch (stateUI)
            {
                case StateUI.InterpreterPanel:
                    _currentWindow = _interpreterWindow;
                    break;
                case StateUI.InfoPanel:
                    _currentWindow = _infoWindow;
                    break;
                default:
                    _currentWindow = null;
                    break;
            }
            
            _currentWindow?.Execute();
            if (isSave)
            {
                _stateUI.Push(stateUI);
            }
        }

        public void RestoreStep()
        {
            if (_stateUI.Count > 0)
            {
                Execute(_stateUI.Pop(), false);
            }
            else
            {
                Execute(StateUI.None, false);
            }
        }
    }
}
