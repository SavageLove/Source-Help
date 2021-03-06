using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;				//You must have all these when making a behavior.

namespace wServer.logic							//This is also required.
{
	partial class BehaviorDb					//This is also required.
	{
		private _ Jesus = () => Behav()		 	//This is also required					//Remember you can rename "Jesus" to whatever you want just make sure that it is not the same as other behaviors. 
			.Init("Jesus",						//This is the enemy name				//Rename "Jesus" to whatever enemy name you are making the behaviors for...such as if I were making a behavior for bes it would be called "Tomb Defender".
				new State(																//If you behavior for the enemy(.Init) has more then 1 State then you need a "state holder" which just holds all the states in 1 state.
					new ConditionalEffect(ConditionEffectIndex.Invincible, true),		//This is how you apply conditions to the enemy you are making the behavior for, and the "true" is if its going to be permanent or not (true = yes, false = no)
					new State("Start",
						new Taunt("I am Jesus"), 										//This is how you can make the enemy talk...in this Taunt Jesus is saying "I am Jesus"
						new Prioritize(													//Prioritize means which the behavior is going this will always run...like a loop 
							new Wander(0.5)												//This is when the enemy is aimlessly wandering at a speed of 0.5(50 spd)
						),																//Since Priortize required a '(' then you will need to close it with a ')'
						new TimedTransition(5000, "Second", false)						//After 5secs(5000ms) it will go the the state called Second and the false is asking if the timed transition will go to a random state or not but since I want it to go to Second I type false
					),
					new State("Second",																								//This is the Second state which will happen after State since it will transition to Second after 5 seconds
						new Taunt("Recive my blessings, but you must say the magic words"),											//Just Jesus talking again
						new ChatTransition("Third", "Thank you", "thank you", "THANK YOU", "THANKYOU", "Thankyou", "thankyou"),		//This will go to state "Third" if the player says one of the six Thank you
						new TimedTransition(10000, "Forth")																			//If the player does not say one of the six thank you in 10 secs then it will go to state "Forth"
					),
					new State("Third",										//This is the "Third" state that will happen if the player types one of the six thank you in less then 10 seconds
						new Taunt("Very well my child take my blessings"),	//Just Jesus talking again
						new Spawn("White Fountain", 1, 1, 900000001),		//White Fountain already has a behavior to heal the player and Jesus just spawns one of them to heal the player
						new TimedTransition(1000, "Goodbye")				//After 1 second It will go to the state "Goodbye"
					),
					new State("Forth",										//This is the "Forth" state that will happen if the player fails to type one of the six thank you in less then 10 seconds
						new Taunt("Very well good luck my child"),			//Just Jesus talking
						new TimedTransition(1000, "Goodbye")				//After 1 second it will go to the state "Goodbye"
					),
					new State("Goodbye",									//This is the "Goodbye" state that will occur after 1 second in the "Third" or "Forth" State
						new Taunt("Goodbye children"),						//Just Jesus talking again
						new Suicide()										//Jesus will suicide instantly which is basically like killing him and if the player did damage to jesus the it will drop loot if they got enough soulbound damage
					)
				),															//This is what closes the State Holder that holds all the internal states
																			//if you wanted to add loot you must add it out of the state holder as such
				new MostDamagers(5, 										//In this the TOP 5 Most Damagers to "jesus" will have a chance of getting the loot in this braket
					new TierLoot(15, ItemType.Armor, 0.5), 					//There is a 0.5(50%) chance for player to get a Tier 15 Armor(Any Class)
																			/*  ItemType.Weapon
																			 * 	ItemType.Armor
																			 * 	ItemType.Potion
																			 * 	ItemType.Ring
																			 * 	ItemType.Ability
																			 */
					new ItemLoot("Sword of Majesty", 0.35)					//There is a 0.35(35%) chance for a player to get a Sword of Majesty
																			/*	You can type any item
																			 * 	if I wanted it to drop an Acclaim I would put "Sword of Acclaim"
																			 *  or if I wanted it to drop The staff of the Fundamental Core then I would type "Staff of the Fundamental Core"
																			 * 	you can add any item just as long as its an actual item in the game
																			 */
				),
				new Threshold(0.5, 											//All players that did more then 0.5(50%) damage of Jesus health will get a chance of getting the loot in this braket
					new TierLoot(14, ItemType.Weapon, 0.4),					//There is a 0.4(40%) chance of getting a T14 Weapon(Any Class)
					new ItemLoot("Annihilation Armor", 0.65)				//There is a 0.65(65%) chance of getting the item "Annihilation Armor"
				)
			); 																// You must always close your .Init, and if it's the last .Init for the whole class then your going to have to add a semi-colen after the parentheses => );
	}
}
/*If you wanted to make jesus shoot then you would add new Shoot(10, 3, 5, projectileIndex: 0, coolDown: 1000, coolDownOffset: 2000)
 * The number 10 is the range it will start shooting at the player
 * The number 3 is the amount of bullets shot at the player and it will automatically get divided by 360 so it will shoot at every 120 angle unless you specify the shoot angle
 * The number 5 is the shoot angle so it will shoot in a spread of 5 each shot so one shot in the middle, then one shot 5 degrees to the left of the middle oshot, then one shot five degrees to the right of the middle shot
 * projectileIndex: 0 is what type of bullet its going to be shooting you can find this info in the XML of the enemy
 * coolDown: 1000 is how long till it will shoot again which is 1 second (1000ms)
 * coolDownOffset: 2000 is how long will it wait to shoot its first shot then after that it will continue by the rules of coolDown
 * There is more but to much to explain in writing but you can see for yourself in the class called Shoot.cs
 */
//This is just a template and not really to be used for actual behaviors but if you were to use this It would work...but only if you have a enemy called Jesus
//There is many more behaviors that I did not mention in this and the best way to learn is to experiment and see what does what :) I hope this helped whoever is reading this 
/* Made by..
 * Love
 * DimitriSavage
 * SavageDimi
 * (Just to let you know that's just all my commenly used usernames in P'servers and forums)
 */
