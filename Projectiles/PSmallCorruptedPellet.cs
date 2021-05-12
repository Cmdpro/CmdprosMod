using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CmdsMod.Projectiles
{
	public class PSmallCorruptedPellet : ModProjectile
	{
		private Player player;
		//float projectile.blockbounce;
		public float speed = 4f;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Corrupted Pellet");     //The English name of the projectile
													  //ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
													  //ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.damage = 5;
			projectile.width = 10;               //The width of projectile hitbox
			projectile.height = 10;              //The height of projectile hitbox
			projectile.scale = 1;
			projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.melee = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 60 * 6;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 0f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = false;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
			aiType = ProjectileID.Bullet;           //Act exactly like default Bullet
			projectile.usesLocalNPCImmunity = false;
			projectile.scale = 0.75f;
			projectile.knockBack = 0;
			
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			projectile.Kill();
		}

        public override bool OnTileCollide(Vector2 oldVelocity) {
			//If collide with tile, reduce the penetrate.
			//So the projectile can reflect at most 5 times
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
		public override void AI()
		{
			for (int i = 0; i < 200; i++)
			{
				NPC target = Main.npc[i];
				//If the npc is hostile
				if (target.friendly == false)
				{
					//Get the shoot trajectory from the projectile and target
					float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
					float shootToY = target.position.Y - projectile.Center.Y;
					float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

					//If the distance between the live targeted npc and the projectile is less than 480 pixels
					if (distance < 480f && !target.friendly && target.active)
					{
						//Divide the factor, 3f, which is the desired velocity
						distance = 3f / distance;

						//Multiply the distance by a multiplier if you wish the projectile to have go faster
						shootToX *= distance * 5;
						shootToY *= distance * 5;

						//Set the velocities to the shoot values
						projectile.velocity.X = shootToX;
						projectile.velocity.Y = shootToY;
					}
					
				}
				if (target.Hitbox.Contains(projectile.position.ToPoint()))
				{
					target.StrikeNPC(150, 0, 0, false, false);
					projectile.Kill();
				}
			}
		}
		private void Target()
		{
			//player = Main.player[Player.FindClosest(projectile.position, projectile.width, projectile.height)];
			//NEED TO GET HOMING WORKING

		}
		private void Move(Vector2 offset)
		{
			// Sets the max speed of the npc.
			Vector2 moveTo = player.Center; // Gets the point that the npc will be moving to.
			Vector2 move = moveTo - projectile.Center;
			float magnitude = Magnitude(move);
			if (magnitude > speed)
			{
				move *= speed / magnitude;
			}
			float turnResistance = 10f; // The larget the number the slower the npc will turn.
			move = (projectile.velocity * turnResistance + move) / (turnResistance + 1f);
			magnitude = Magnitude(move);
			if (magnitude > speed)
			{
				move *= speed / magnitude;
			}
			projectile.velocity = move;
			RotateNPCToTarget();
		}

		public override void Kill(int timeLeft)
		{
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
		private float Magnitude(Vector2 mag)
		{
			return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
		}
		private void RotateNPCToTarget()
		{
			if (player == null) return;
			Vector2 direction = projectile.Center - player.Center;
			float rotation = (float)Math.Atan2(direction.Y, direction.X);
			projectile.rotation = rotation + ((float)Math.PI * 0.5f);
		}

	}
}