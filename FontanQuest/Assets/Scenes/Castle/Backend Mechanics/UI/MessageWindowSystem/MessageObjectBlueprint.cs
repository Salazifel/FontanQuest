using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static MessageWindow;

public static class MessageObjectBlueprint 
{
    public class messageObject {
        public string headlineText;
        public string mainTextContent;
        public string leftButtonText;
        public UnityAction leftButtonCallback;
        public string rightButtonText;
        public UnityAction rightButtonCallback;
        public string middleButtonText;
        public UnityAction middleButtonCallback;
        public Character_options character_Options;
        public AnimationLibrary.Animations animations;

        public messageObject(string _headlineText,
                                string _mainTextContent, 
                                string _leftButtonText, 
                                UnityAction _leftButtonCallback, 
                                string _rightButtonText, 
                                UnityAction _rightButtonCallback, 
                                string _middleButtonText, 
                                UnityAction _middleButtonCallback, 
                                Character_options _character_Options, 
                                AnimationLibrary.Animations _animations) 
        {
            headlineText = _headlineText;
            mainTextContent = _mainTextContent;
            leftButtonText = _leftButtonText;
            leftButtonCallback = _leftButtonCallback;
            rightButtonText = _rightButtonText;
            rightButtonCallback = _rightButtonCallback;
            middleButtonText = _middleButtonText;
            middleButtonCallback = _middleButtonCallback;
            character_Options = _character_Options;
            animations = _animations;
        }
    }
}
