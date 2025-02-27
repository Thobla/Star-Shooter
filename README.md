# Game description

As a star ship, your goal is to destroy evil planets, but beware, cause there are dangerous enemy space ships around every corner, and asteroids large enough to annihilate entire fleets on impact! To full-fill your duty, you have been granted a powerful laser to shoot them down, but don't hesitate to pick up and use others you find along the way.


# MVP

- [ ] Sprite and hitbox for player
- [X] Player with basic movement (accelerate by thrusting forward)
- [ ] Asteroids colliding with player
- [ ] Player gun to destroy asteroids
- [ ] Player killable
- [ ] Enemy star ships following player
- [ ] Enemy star ships firing at player
- [ ] Sprites to make it feel good

# Illustration Idea

![StarShooterIllustration.png](https://github.com/Thobla/Star-Shooter/blob/main/StarShooterIllustration.png?raw=true)

# Components

## Player

In a finished and polished game, the following points should be included: 
- [ ] Movement
	- [ ] Max speed limit without turbo
	- [ ] Smooth acceleration/deceleration
	- [ ] Looks at cursor (with or without turn speed limit?)
	- [ ] Limited boost
- [ ] Shooting
	- [ ] Standard laser gun, unlimited ammo
	- [ ] Rocket gun
		- [ ] Explosion on impact
		- [ ] Limited ammo
		- [ ] Refills over time
		- [ ] Cooldown
- [ ] Impact
	- [ ] Can take damage
	- [ ] Hp between 0-100 (regens over time)
	- [ ] Shield (regens on pickup)
