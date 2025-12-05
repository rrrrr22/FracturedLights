using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;


namespace RisingShot.Resources.Events
{
    public interface IStrategyPattern
    {
        public void OnEntitySummon(ref Entity entity) { }
        //LivingActor.cs
        public void OnEntityHit(ref Hit hit) { }
        //InteractionRaycast.cs
        public void OnInteraction(ref IAreaInteractable scene) { }
        //Projectile.cs
        public bool OnProjectileBodyHit(Projectile projectile, Utils.CollisionData data) => false;
        //LivingActor.cs
        public void OnProjectileActorHit(ref Hit hit) { }
        //Pickup.cs
        public void OnPickup(LivingActor actor) { }
        //LivingActor.cs
        public void OnPreUpdate(LivingActor actor) { }
        //LivingActor.cs
        public void OnPostUpdate(LivingActor actor) { }
        //LivingActor.cs
        public void OnDeath(ref Hit hit) { }
        //LivingActor.cs
        public void OnSpawn(LivingActor actor) { }
        //LivingActor.cs
        public void OnKill(Hit hit) { }
        //Hand.cs
        public void OnPreReload(LivingActor actor) { }
        //Hand.cs
        public void OnPostReload(LivingActor actor) { }
        //LivingActor.cs
        public void OnRemove(LivingActor actor) { }
        //IAreaInteractable.cs
        public void CostReduction(ref int cost, IAreaInteractable interactable) {}
    }
}
