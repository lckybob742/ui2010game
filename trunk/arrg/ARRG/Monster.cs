﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using Model = GoblinXNA.Graphics.Model;
using GoblinXNA;
using GoblinXNA.Graphics;
using GoblinXNA.SceneGraph;
using GoblinXNA.Graphics.Geometry;
using GoblinXNA.Graphics.ParticleEffects;
using GoblinXNA.Device.Generic;
using GoblinXNA.Device.Capture;
using GoblinXNA.Device.Vision;
using GoblinXNA.Device.Vision.Marker;
using GoblinXNA.Device.Util;
using GoblinXNA.Physics;
using GoblinXNA.Helpers;

namespace ARRG_Game
{
    public class Monster
    {
        protected TransformNode transNode;
        protected int health, power;
        protected double hit, dodge, crit;
        protected List<int> dmgMods;
        protected List<int> healthMods;
        protected List<int> dmgTaken;
        protected List<int> dmgPrevented;
        protected string name;

        public Monster(string name,String model, int health, int power)
        {
            this.name = name;
            this.health = health;
            this.power = power;

            dmgMods = new List<int>();
            healthMods = new List<int>();
            dmgTaken = new List<int>();
            dmgPrevented = new List<int>();

            //********Test code****
            Material robotMaterial = new Material();
            robotMaterial.Diffuse = Color.Orange.ToVector4();
            robotMaterial.Specular = Color.White.ToVector4();
            robotMaterial.SpecularPower = 2;
            robotMaterial.Emissive = Color.Black.ToVector4();

            ModelLoader loader = new ModelLoader();
            Model robotModel = (Model)loader.Load("Models/", model);
            GeometryNode robotNode = new GeometryNode("Robot");
            robotNode.Model = robotModel;
            robotNode.Model.UseInternalMaterials = true;
            //robotNode.Material = robotMaterial;
            
            transNode = new TransformNode();
            transNode.AddChild(robotNode);
            transNode.Scale *= 0.03f;
            transNode.Translation += new Vector3(0, 0, 25);
            //********End Test code****
        }
        public Monster() { }

        public int Health
        {
          get { return health; }
          set { health = value; }
        }

        public int Power
        {
          get { return power; }
          set { power = value; }
        }

        public String Name
        {
          get { return name; }
          set { name = value; }
        }

        public void adjustPower(int mod)
        {
            power = power + mod;
        }

        public void adjustHealth(int mod)
        {
            health = health + mod;
        }

        public void addMod(int dmg, int health)
        {
            dmgMods.Add(dmg);
            healthMods.Add(health);
        }
        public void dealDirectDmg(int dmg)
        {
            dmgTaken.Add(dmg);
        }
        public void preventDmg(int health)
        {
            dmgPrevented.Add(health);
        }

        public void newTurn()
        {
            dmgTaken.Clear();
            dmgMods.Clear();
            healthMods.Clear();
            dmgPrevented.Clear();
        }

        public TransformNode TransNode
        {
            get { return transNode; }
            set { transNode = value;}
        }
    }

    class MonsterBuilder
    {
        CreatureType type;
        protected String name;
        protected String model;
        int health;
        int power;
        public MonsterBuilder(CreatureType type,String name,String model, int health, int power)
        {
            this.name = name;
            this.health = health; 
            this.power = power;
            this.type = type;
            this.model = model;
        }
        public Monster createMonster()
        {
            switch (type)
            {
                case CreatureType.BEASTS: break;
                case CreatureType.DRAGONKIN: break;
                case CreatureType.ROBOT: break;
            }
            return new Monster(name,model, health, power);
        }
    }

}
