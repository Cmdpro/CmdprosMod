using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CmdsMod.Projectiles
{
	public class SmallCorruptedPellet : ModProjectile
	{
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
			projectile.friendly = false;         //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
			projectile.melee = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
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
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			projectile.Kill();
			target.immune = false;
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
			Vector2 targetPosition = new Vector2(0, 0);
			int maxDistance = 2 * 200 * 200;
			bool found = false;
			foreach (Player n in Main.player)
			{ 
				if (n.statLifeMax > 0 && n.statLife > 0)
				{
					Vector2 pos = n.position;
					int x = (int)pos.X;
					int y = (int)pos.Y;

					if ((x - (int)projectile.position.X) * (x - (int)projectile.position.X)
						+ (y - (int)projectile.position.Y) * (y - (int)projectile.position.Y)
						< maxDistance)
					{
						maxDistance = (x - (int)projectile.position.X) * (x - (int)projectile.position.X)
						+ (y - (int)projectile.position.Y) * (y - (int)projectile.position.Y);
						targetPosition = pos;
						found = true;
					}
				}

			}
			if (found)
			{
				if (projectile.timeLeft >= 301)
				{
					speed = 4f;
				} else
                {
					speed = 5f;
				}
				if (projectile.timeLeft >= 301)
				{
					float inertia = 10f;
					Vector2 direction = targetPosition - projectile.position;

					direction.Normalize();
					direction *= speed;

					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			if (projectile.timeLeft >= 301)
			{
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.Pi / 2;
			}
		}

		public override void Kill(int timeLeft)
		{
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
        
    }
}