﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SS3D.Core
{
    /// <summary>
    /// Class used to get game systems, using generics and then making cache of said systems
    /// </summary>
    public static class GameSystems
    {
        private static readonly Dictionary<Type, object> Systems = new();

        /// <summary>
        /// Get any system at runtime, make sure there's no duplicates before using
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : Object
        {
            if (Systems.TryGetValue(typeof(T), out object match))
            {
                return (T)match;
            }

            match = Object.FindObjectOfType<T>();

            if (match == null)
            {
                Debug.Log($"[{nameof(GameSystems)}] - Couldn't find system of {nameof(T)} in the scene");
            }

            Systems.Add(typeof(T), match);

            return (T)match;
        }
    }
}