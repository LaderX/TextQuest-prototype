using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Lader.StoryBuilder
{
    public class StoryBuilderWindow : EditorWindow
    {
        /*
        private static readonly Color BgColor = new Color(56 / 255f, 56 / 255f, 56 / 255f);
        #region factory
        [MenuItem("Window/StoryBuilder/Open Editor")]
        public static void Create()
        {
            var window = GetWindow<StoryBuilderWindow>("StoryBuilder");
            window.position = new Rect(100, 100, 400, 400);
            window.Show();
        }
        #endregion

        #region events
        public event Action<EventType, Vector2, KeyCode> OnKeyEvent;
        #endregion

        #region fields

        //public ApartmentBuilderGrid Grid;

        /*
        private Toolbar _Toolbar;
        private EditorWindowState _CurrentState;
        private Dictionary<EditorWindowState, StateApartmentBuilder> _States;
        private Vector3? _LastMousePosition;
        */
       // #endregion


            /*
        int toolbarInt = 0;
        string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };

        void OnGUI()
        {
            //toolbarInt = GUILayout.Toolbar(toolbarInt, toolbarStrings);
            GUILayout.Label("This is an sized label");
            windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "My Window", GUILayout.Width(100));
        }

        void DoMyWindow(int windowID)
        {
            // This button is too large to fit the window
            // Normally, the window would have been expanded to fit the button, but due to
            // the GUILayout.Width call above the window will only ever be 100 pixels wide
            if (GUILayout.Button("Please click me a lot"))
            {
                print("Got a click");
            }
        }
        */
    }
}