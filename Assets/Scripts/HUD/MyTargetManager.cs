using Assets.Scripts.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.HUD
{
    public class MyTargetManager : MyMonoBehaviour
    {
        public Transform Player;
        public MyTargetDirection TargetDirectionPrefab;
        public List<MyTargetDirection> Directions = new();
        public List<MyTarget> Targets = new();

        protected override void Start()
        {
            base.Start();
            if (MyEventHandler)
                MyEventHandler.OnLevelLoaded += OnLevelLoaded;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (MyEventHandler)
                MyEventHandler.OnLevelLoaded -= OnLevelLoaded;
        }

        private void OnLevelLoaded(MyLevel obj)
        {
            UpdateTargets();
        }

        public void UpdateTargets()
        {
            Targets = FindObjectsOfType<MyTarget>().ToList();
            UpdateTargetDirections();
        }

        public void UpdateTargetDirections()
        {
            for (int i = 0; i < Directions.Count; ++i)
                Directions[i].Target = Targets[i];

            for (int i =  Directions.Count; i < Targets.Count; ++i)
            {
                Directions.Add(Instantiate(TargetDirectionPrefab, transform));
                Directions[i].Player = Player;
                Directions[i].Target = Targets[i];
            }

            for (int i = Directions.Count - 1; i >= Targets.Count; --i)
                Directions.RemoveAt(i);
        }

    }
}
