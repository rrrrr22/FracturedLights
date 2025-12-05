using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace RisingShot.Resources.Events
{
    [GlobalClass]
    public partial class StrategyBase : Resource
    {

        [Export] public string name;
        [Export] public string description;
        [Export] public Texture2D sprite;
        [Export] public bool isHidden = false;
        // [Export] public Rarity rarity;

    }
}
