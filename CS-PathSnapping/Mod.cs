using System;
using ICities;

namespace CS_PathSnapping
{
    public class Mod : IUserMod
    {
        public string Name => "Path Snapping";
        public string Description => "Buildings snap to paths and no longer snap to the grid. Useful for stuff, I guess.";
    }

    public class Ingame : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            for(uint i = 0; i < PrefabCollection<BuildingInfo>.LoadedCount(); i++)
            {
                BuildingInfo building = PrefabCollection<BuildingInfo>.GetLoaded(i);
                if (building.m_placementMode == BuildingInfo.PlacementMode.Roadside)
                {
                    building.m_placementMode = BuildingInfo.PlacementMode.PathsideOrGround;
                    //building.m_placementOffset = 0f;
                }
            }
        }
    }
}
