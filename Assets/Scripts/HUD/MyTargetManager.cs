using Assets.Scripts.Core;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.HUD
{
    public class MyTargetManager : MyMonoBehaviour
    {
        public const float TimeBetweenRefresh = 1f;


        public Transform Player;
        public MyTargetDirection TargetDirectionPrefab;
        private readonly List<MyTargetDirection> Directions = new();
        private List<MyTarget> Targets = new();
        private float timeUntilRefresh = TimeBetweenRefresh;


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

        private void Update()
        {
            timeUntilRefresh -= Time.deltaTime;
            if (timeUntilRefresh <= 0)
            {
                UpdateTargets();
                timeUntilRefresh += TimeBetweenRefresh;
            }
        }

        private void OnLevelLoaded(MyLevel obj)
        {
            UpdateTargets();
        }

        public void UpdateTargets()
        {
            Targets = FindObjectsOfType<MyTarget>().Where((MyTarget target) => !!target && !target.IsDestroyed()).ToList();
            UpdateTargetDirections();
        }

        public void UpdateTargetDirections()
        {
            for (int i = 0; i < Directions.Count && i < Targets.Count; ++i)
                Directions[i].Target = Targets[i];

            for (int i = Directions.Count; i < Targets.Count; ++i)
            {
                Directions.Add(Instantiate(TargetDirectionPrefab, transform));
                Directions[i].Player = Player;
                Directions[i].Target = Targets[i];
            }

            for (int i = Directions.Count - 1; i >= Targets.Count; --i)
            {
                Destroy(Directions[i].gameObject);
                Directions.RemoveAt(i);
            }
        }

    }
}
