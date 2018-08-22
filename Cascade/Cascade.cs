using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Initializers;
using Terraria.IO;
using Terraria.GameContent;
using Terraria.ModLoader;
using System.Linq;
using Terraria.UI;
using Terraria.GameContent.UI;
using Cascade.Event;
namespace Cascade
{
	public class Cascade : Mod
	{
		 internal static Cascade instance; 
		public Cascade()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
		public override void Load()

        {
            instance = this;
			Filters.Scene["Cascade:Shrek"] = new Filter(new BeeMovie("FilterMiniTower").UseColor(0f, 0f, 0f).UseOpacity(0f), EffectPriority.VeryLow);
			SkyManager.Instance["Cascade:Shrek"] = new CascadeSky();
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
        
            if (CascadeWorld.TheCascade)
            {
                int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
                LegacyGameInterfaceLayer CascadeSpoon = new LegacyGameInterfaceLayer("Cascade: Spoon",
                    delegate
                    {
                        DrawCascadeUi(Main.spriteBatch);
                        return true;
                    },
                    InterfaceScaleType.UI);
                layers.Insert(index, CascadeSpoon);
            }
        }
		public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            Mod mod = ModLoader.GetMod("Cascade");
            int[] NoOverride = {MusicID.Boss1, MusicID.Boss2, MusicID.Boss3, MusicID.Boss4, MusicID.Boss5,
                MusicID.LunarBoss, MusicID.PumpkinMoon, MusicID.TheTowers, MusicID.FrostMoon, MusicID.GoblinInvasion,
                MusicID.PirateInvasion, GetSoundSlot(SoundType.Music, "Sounds/Music/Cascade")};

            bool playMusic = true;
           	if (Main.gameMenu)
				return;
			if (priority > MusicPriority.Event)
				return;
			Player player = Main.LocalPlayer;
			if (!player.active)
				return;
			MyPlayer spirit = player.GetModPlayer<MyPlayer>();
			if (CascadeWorld.TheCascade)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/Cascade");
				priority = MusicPriority.Event;
			}
          
        }

		public void DrawCascadeUi(SpriteBatch spriteBatch)
        {
            CascadePlayer modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<CascadePlayer>();
            if (CascadeWorld.TheCascade)
            {
				string customEventName = "The Cascade";
                float alpha = 0.5f;
                Texture2D backGround1 = Main.colorBarTexture;
                Texture2D progressColor = Main.colorBarTexture;
                Texture2D CascadeIcon = Cascade.instance.GetTexture("Icon");
                float scmp = 0.5f + 0.75f * 0.5f;
                Color descColor = new Color(77, 39, 135);
                Color waveColor = new Color(255, 241, 51);
                Color barrierColor = new Color(255, 241, 51);
                const int offsetX = 20;
                const int offsetY = 20;
                int width = (int)(200f * scmp);
                int height = (int)(46f * scmp);
                Rectangle waveBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 23f), new Vector2(width, height));
                Utils.DrawInvBG(spriteBatch, waveBackground, new Color(63, 65, 151, 255) * 0.785f);
                string waveText = "Cleared " + CascadeWorld.CascadePoints + "%";
                Utils.DrawBorderString(spriteBatch, waveText, new Vector2(waveBackground.X + waveBackground.Width / 2, waveBackground.Y + 5), Color.White, scmp * 0.8f, 0.5f, -0.1f);
                Rectangle waveProgressBar = Utils.CenteredRectangle(new Vector2(waveBackground.X + waveBackground.Width * 0.5f, waveBackground.Y + waveBackground.Height * 0.75f), new Vector2(progressColor.Width, progressColor.Height));
                Rectangle waveProgressAmount = new Rectangle(0, 0, (int)(progressColor.Width * 0.01f * MathHelper.Clamp(CascadeWorld.CascadePoints, 0f, 100f)), progressColor.Height);
                Vector2 offset = new Vector2((waveProgressBar.Width - (int)(waveProgressBar.Width * scmp)) * 0.5f, (waveProgressBar.Height - (int)(waveProgressBar.Height * scmp)) * 0.5f);
                spriteBatch.Draw(backGround1, waveProgressBar.Location.ToVector2() + offset, null, Color.White * alpha, 0f, new Vector2(0f), scmp, SpriteEffects.None, 0f);
                spriteBatch.Draw(backGround1, waveProgressBar.Location.ToVector2() + offset, waveProgressAmount, waveColor, 0f, new Vector2(0f), scmp, SpriteEffects.None, 0f);
                const int internalOffset = 6;
                Vector2 descSize = new Vector2(154, 40) * scmp;
                Rectangle barrierBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 19f), new Vector2(width, height));
                Rectangle descBackground = Utils.CenteredRectangle(new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), descSize * 0.9f);
                Utils.DrawInvBG(spriteBatch, descBackground, descColor * alpha);
                int descOffset = (descBackground.Height - (int)(32f * scmp)) / 2;
                Rectangle icon = new Rectangle(descBackground.X + descOffset + 7, descBackground.Y + descOffset, (int)(32 * scmp), (int)(32 * scmp));
                spriteBatch.Draw(CascadeIcon, icon, Color.White);
                Utils.DrawBorderString(spriteBatch, customEventName, new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), Color.White, 0.8f, 0.3f, 0.4f);
            }
        }
	}
}
