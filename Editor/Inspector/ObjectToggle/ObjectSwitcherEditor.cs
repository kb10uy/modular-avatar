﻿#region

using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

#endregion

namespace nadena.dev.modular_avatar.core.editor.ShapeChanger
{
    [CustomEditor(typeof(ModularAvatarObjectToggle))]
    public class ObjectSwitcherEditor : MAEditorBase
    {
        [SerializeField] private StyleSheet uss;
        [SerializeField] private VisualTreeAsset uxml;


        protected override void OnInnerInspectorGUI()
        {
            throw new NotImplementedException();
        }

        protected override VisualElement CreateInnerInspectorGUI()
        {
            var root = uxml.CloneTree();
            Localization.UI.Localize(root);
            root.styleSheets.Add(uss);

            root.Bind(serializedObject);
            
            ROSimulatorButton.BindRefObject(root, target);

            var listView = root.Q<ListView>("Shapes");

            listView.showBoundCollectionSize = false;
            listView.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;

            return root;
        }
    }
}