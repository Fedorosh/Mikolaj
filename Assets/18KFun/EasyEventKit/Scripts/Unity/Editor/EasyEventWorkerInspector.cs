using UnityEditor;

namespace EasyEvent.Editor
{
    [CustomEditor(typeof(EasyEventWorker))]
    public class EasyEventWorkerInspector : UnityEditor.Editor
    {
        private bool _ifFolderOpened = false;
        public override void OnInspectorGUI()
        {
            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available only on runtime.", MessageType.Info);
                return;
            }

            var eventKit = EasyEventKit.Instance;
            
            EditorGUILayout.LabelField("EasyEventKit");

            EditorGUILayout.LabelField("RegisteredEventCount:", eventKit.RegisteredEventCount.ToString());
            EditorGUILayout.LabelField("EventQueueCount:", eventKit.EventQueueCount.ToString());
            EditorGUILayout.LabelField("CachedHandlerPoolCount:", eventKit.CachedHandlerPoolCount.ToString());
            
            DrawEventDictionary();
            
            Repaint();
        }

        private void DrawEventDictionary()
        {
            _ifFolderOpened = EditorGUILayout.Foldout(_ifFolderOpened, "Event Dictionary:");
            if (_ifFolderOpened)
            {
                EditorGUILayout.BeginVertical("box");
                {
                    EasyEventKit.Instance.DebugLoopDic((evtId, handleCount) =>
                    {
                        EditorGUILayout.LabelField("EventId", evtId.ToString());
                        EditorGUILayout.LabelField("Handlers Count:", handleCount.ToString());
                        EditorGUILayout.Separator();
                    });
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.Separator();
            }
        }
    }
}