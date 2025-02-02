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

using GoblinXNA;
using GoblinXNA.Graphics;
using GoblinXNA.SceneGraph;
using Model = GoblinXNA.Graphics.Model;
using GoblinXNA.Graphics.Geometry;
using GoblinXNA.Device.Capture;
using GoblinXNA.Device.Vision;
using GoblinXNA.Device.Vision.Marker;
using GoblinXNA.Device.Util;
using GoblinXNA.Physics;
using GoblinXNA.Helpers;
using GoblinXNA.UI;
using GoblinXNA.UI.UI2D;
using GoblinXNA.Device.Generic;

namespace ARRG_Game
{
    class Brb
    {
        Scene scene;
        MenuStates curState;
        InGameStates gameState;
        ContentManager content;
        G2DLabel brbButton;
        public Brb(MenuStates menuState, InGameStates gameState)
        {
            this.scene = GlobalScene.scene;
            this.curState = menuState;
            
            this.content = State.Content;
            this.gameState = gameState;

            createObject();
        }

        private void createObject()
        {
            brbButton = new G2DLabel();
            brbButton.Bounds = new Rectangle(342, 0, 116, 116);
            brbButton.Transparency = 1.0f;
            brbButton.BackgroundColor = Color.Black;
            brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbDraw");
            brbButton.MouseReleasedEvent += new MouseReleased(updateMenuBrb);
            KeyboardInput.Instance.KeyPressEvent += new HandleKeyPress(KeyPressHandler);

            scene.UIRenderer.Add2DComponent(brbButton);
        }
        public void Kill()
        {
            scene.UIRenderer.Remove2DComponent(brbButton);
            brbButton.Enabled = false;
        }
        public void updateMenuState(MenuStates s)
        {
            curState = s;
        }
        public void updateGameState(InGameStates s)
        {
            gameState = s;
        }
        public MenuStates getMenuState()
        {
            return curState;
        }
        public InGameStates getInGameState()
        {
            return gameState;
        }
        public void setNextInGame()
        {
            updateMenuBrb(0, new Point());
        }
        private void updateMenuBrb(int mouseButton, Point mouse)
        {
            if (mouseButton != 0)
                return;
            switch (curState)
            {
                case MenuStates.INGAME: gameState = (gameState == InGameStates.DISCARD ? InGameStates.DRAW : ++gameState); brbButton.Text = "";
                    switch (gameState)
                    {
                        case InGameStates.ATTACK:
                            brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbTargeting");
                            break;
                        case InGameStates.DAMAGE:
                            brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbAttack");
                            break;
                        case InGameStates.DISCARD:
                            brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbDiscard");
                            break;
                        case InGameStates.DRAW:
                            brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbDraw");
                            break;
                        case InGameStates.SUMMON:
                            brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbSummon");
                            break;
                        case default(InGameStates):
                            break;
                    }
                    break;
                case MenuStates.INVENTORY:
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbInventory");
                    break;
                case MenuStates.MARKET:
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbMarket");
                    break;
                case MenuStates.TITLE:
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbArrg");
                    break;
                case MenuStates.TALENT:
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbTalent");
                    break;
                case default(MenuStates):
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbArrg");
                    break;
            }
        }


        private void KeyPressHandler(Keys keys, KeyModifier modifier)
        {
         
          if (keys == Keys.Space)
          {
            switch (curState)
            {
              case MenuStates.INGAME: gameState = (gameState == InGameStates.DISCARD ? InGameStates.DRAW : ++gameState); brbButton.Text = "";
                switch (gameState)
                {
                  case InGameStates.ATTACK:
                        brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbTargeting");
                    break;
                  case InGameStates.DAMAGE:
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbAttack");
                    break;
                  case InGameStates.DISCARD:
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbDiscard");
                    break;
                  case InGameStates.DRAW:
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbDraw");
                    break;
                  case InGameStates.SUMMON:
                    brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbSummon");
                    break;
                  case default(InGameStates):
                    break;
                }
                break;
              case MenuStates.INVENTORY:
                brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbInventory");
                break;
              case MenuStates.MARKET:
                brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbMarket");
                break;
              case MenuStates.TITLE:
                brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbArrg");
                break;
              case MenuStates.TALENT:
                brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbTalent");
                break;
              case default(MenuStates):
                brbButton.Texture = content.Load<Texture2D>("Textures/brb/brbArrg");
                break;
            }

          }
        }

    }
}
