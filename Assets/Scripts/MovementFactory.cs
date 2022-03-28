using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Factory {
    public abstract class Movement 
    {
        public abstract string Name { get; }
        public abstract void Process();
    }

    public class Forward : Movement
    {
        public override string Name => "forward";
        public override void Process()
        {
            GameObject.FindObjectOfType<Player>().MoveForward();
        }
    }
    
    public class Back : Movement
    {
        public override string Name => "back";
        public override void Process()
        {
            GameObject.FindObjectOfType<Player>().MoveBack();
        }
    }

    public class MovementFactory
    {
        private static Dictionary<string, Type> movementsByName;
        private static bool IsInitialized => movementsByName != null;

        public Dictionary<string, Type> MovementsByName
        {
            get => movementsByName;
            set => movementsByName = value;
        }

        public static void InitializeFactory()
        {
            if (IsInitialized)
                return;
            
            var movementTypes = Assembly.GetAssembly(typeof(Movement)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Movement)));

            movementsByName = new Dictionary<string, Type>();

            foreach (var type in movementTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Movement;
                movementsByName.Add(tempEffect.Name, type);
            }
        }

        public static Movement GetMovement(string movementType)
        {
            InitializeFactory();
            
            if (movementsByName.ContainsKey(movementType))
            {
                Type type = movementsByName[movementType];
                var movement = Activator.CreateInstance(type) as Movement;
                return movement;
            }

            return null;
        }

        internal IEnumerable<string> GetMovementNames()
        {
            InitializeFactory();
            return movementsByName.Keys;
        }
    }
}