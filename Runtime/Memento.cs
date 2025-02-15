﻿using System;
using System.Collections.Generic;
using AceLand.MementoService.Core;
using AceLand.MementoService.ProjectSetting;
using UnityEngine;

namespace AceLand.MementoService
{
    public static partial class Memento
    {
        internal static AceLandMementoSettings Settings
        {
            get
            {
                _settings ??= Resources.Load<AceLandMementoSettings>(nameof(AceLandMementoSettings));
                return _settings;
            }
        }
        
        private static AceLandMementoSettings _settings;

        internal static void Initialization()
        {
            Debug.Log($"Memento Service Mode : {Settings.MementoServiceMode.ToName()}");
            
            if (Settings.MementoServiceMode is MementoServiceMode.LocalOnly) return;

            _mementoServices = new Dictionary<Type, IMementoService>();
            Debug.Log($"Memento Background Service is Ready");
        }

        public static MementoService<T> BuildLocalService<T>() =>
            MementoService<T>.Build();

        public static MementoService<T> BuildLocalService<T>(int historyLimit) =>
            MementoService<T>.Build(historyLimit);
    }
}