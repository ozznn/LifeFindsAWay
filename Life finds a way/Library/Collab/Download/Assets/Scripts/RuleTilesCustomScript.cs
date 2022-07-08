using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]

public class RuleTilesCustomScript : RuleTile<RuleTilesCustomScript.Neighbor> {
    
    public string tileID;
    public int siblingGroup;

    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Sibling = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        RuleTilesCustomScript RuleTilesCustomScript = tile as RuleTilesCustomScript;
        switch (neighbor) {
            case Neighbor.Sibling: return RuleTilesCustomScript && RuleTilesCustomScript.siblingGroup == siblingGroup;
        }
        return base.RuleMatch(neighbor, tile);
    }
}