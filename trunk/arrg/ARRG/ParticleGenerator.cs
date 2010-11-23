﻿using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GoblinXNA.SceneGraph;
using GoblinXNA.Graphics.ParticleEffects;

namespace ARRG_Game
{
    class ParticleLineGenerator
    {
        Vector3 source, target;
        ParticleNode lineEffectNode;

        public ParticleNode addParticle(String name)
        {
            ParticleEffect lineParticles = new FireParticleEffect();
            lineParticles.TextureName = name;
            lineParticles.MaxHorizontalVelocity = lineParticles.MinHorizontalVelocity;
            lineParticles.MaxVerticalVelocity = lineParticles.MinVerticalVelocity;
            lineParticles.MinStartSize = 2f;
            lineParticles.MaxStartSize = 2f;
            lineParticles.MaxEndSize = lineParticles.MaxStartSize;
            lineParticles.MinEndSize = lineParticles.MinStartSize;
            lineParticles.EndVelocity = 0;
            lineParticles.MinColor = new Color(0, 0, 0, 255);
            lineParticles.MaxColor = new Color(255, 255, 255, 255);
            lineEffectNode = new ParticleNode();
            lineEffectNode.ParticleEffects.Add(lineParticles);

            lineParticles = new FireParticleEffect();
            lineParticles.TextureName = name;
            lineParticles.MaxHorizontalVelocity = lineParticles.MinHorizontalVelocity;
            lineParticles.MaxVerticalVelocity = lineParticles.MinVerticalVelocity;
            lineParticles.MinStartSize = 2f;
            lineParticles.MaxStartSize = 2f;
            lineParticles.MaxEndSize = lineParticles.MaxStartSize;
            lineParticles.MinEndSize = lineParticles.MinStartSize;
            lineParticles.EndVelocity = 0;
            lineParticles.MinColor = new Color(0, 0, 0, 255);
            lineParticles.MaxColor = new Color(255, 255, 255, 255);
            lineEffectNode.ParticleEffects.Add(lineParticles);

            lineParticles = new FireParticleEffect();
            lineParticles.TextureName = name;
            lineParticles.MaxHorizontalVelocity = lineParticles.MinHorizontalVelocity;
            lineParticles.MaxVerticalVelocity = lineParticles.MinVerticalVelocity;
            lineParticles.MinStartSize = 2f;
            lineParticles.MaxStartSize = 2f;
            lineParticles.MaxEndSize = lineParticles.MaxStartSize;
            lineParticles.MinEndSize = lineParticles.MinStartSize;
            lineParticles.EndVelocity = 0;
            lineParticles.MinColor = new Color(0, 0, 0, 255);
            lineParticles.MaxColor = new Color(255, 255, 255, 255);
            lineEffectNode.ParticleEffects.Add(lineParticles);

            lineEffectNode.UpdateHandler += new ParticleUpdateHandler(UpdateLine);
            lineEffectNode.Enabled = false;

            return lineEffectNode;

        }
        public void update(Vector3 source, Vector3 target)
        {
            this.source = source;
            this.target = target;
            if (!lineEffectNode.Enabled)
                lineEffectNode.Enabled = true;
        }
        public void disable()
        {
            lineEffectNode.Enabled = false;
        }
        public void enable()
        {
            lineEffectNode.Enabled = true;
        }
        private void UpdateLine(Matrix worldTransform, List<ParticleEffect> particleEffects)
        {
            if(!lineEffectNode.Enabled)
                lineEffectNode.Enabled = true;
            if (Vector3.Zero.Equals(target))
                return;
            Vector3 vel = target - source;
            foreach (ParticleEffect particle in particleEffects)
            {

                // Add 10 fire particles every frame
                for (int k = 0; k < 20; k++)
                {
                    if (!Vector3.Zero.Equals(worldTransform.Translation))
                        particle.AddParticle(source, vel);
                }
            }
        }

    }

    class FireGenerator
    {
        Vector3 source, target;
        ParticleNode lineEffectNode;

        public ParticleNode addParticle()
        {
            ParticleEffect lineParticles = new FireParticleEffect();
            lineEffectNode = new ParticleNode();
            lineEffectNode.ParticleEffects.Add(lineParticles);

            lineParticles = new FireParticleEffect();
            lineEffectNode.ParticleEffects.Add(lineParticles);

            lineParticles = new FireParticleEffect();
            lineEffectNode.ParticleEffects.Add(lineParticles);

            lineEffectNode.UpdateHandler += new ParticleUpdateHandler(UpdateLine);
            lineEffectNode.Enabled = false;

            return lineEffectNode;

        }
        public void update(Vector3 source, Vector3 target)
        {
            this.source = source;
            this.target = target;
        }
        public void disable()
        {
            lineEffectNode.Enabled = false;
        }
        public void enable()
        {
            lineEffectNode.Enabled = true;
        }
        public void setSource(Vector3 source)
        {
            this.source = source;
        }
        private void UpdateLine(Matrix worldTransform, List<ParticleEffect> particleEffects)
        {
            if (Vector3.Zero.Equals(target))
                return;
            Vector3 vel = target - source;
            foreach (ParticleEffect particle in particleEffects)
            {

                // Add 10 fire particles every frame
                for (int k = 0; k < 20; k++)
                {
                    if (!Vector3.Zero.Equals(worldTransform.Translation))
                        particle.AddParticle(source, vel);
                }
            }
        }

    }
}