using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ TheDevil = () => Behav()                      //Becareful I am known to make very, very, very hard dungeons so if you plan on testing this watch out
        .Init("The Devil",
            new State(
                new State("Idle",                               //In this state The Devil is waiting for the player to be in radius(or diamater) of 10 to go to Start
                    new PlayerWithinTransition(10, "Start"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable)            //The Devil is invulnerable while waiting for the player
                    ),
                new State("Start",                              //In this state the Devil is talking before he begins to attack the Player
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),           //The Devil is invulnerable while talking
                    new TimedTransition(7000, "Fight"),
                    new State("Talk",
                        new Taunt("Welcome to hell my friend"),
                        new TimedTransition(1500, "Talk2")                      //Remember that time is based of ms so 1500ms is just 1.5 seconds
                        ),
                    new State("Talk2",
                        new Taunt("I've been waiting for you"),
                        new TimedTransition(1500, "Talk3")
                        ),
                     new State("Talk3",
                        new Taunt("You have been very naughty..."),
                        new TimedTransition(1500, "Talk4")
                        ),
                    new State("Talk4",
                        new Taunt("And you know what we do to naughty people?"),
                        new TimedTransition(1500, "Talk5")
                        ),
                    new State("Talk5",
                        new Taunt("Kill them!")
                        )
                    ),
                new State("Fight",                                          //In this state The Devil begins to Fight the player by shooting at the player
                    new Shoot(20, 5, 1, 0, coolDown: 50, coolDownOffset: 500),       //The Devil will shoot this forever...range: 20....shots:5...spread:1....projectileId:0....cooldown:0.05 secs.....time till first shot:0.5 secs
                    new State("Fight1",
                        new Taunt("Feel the heat of my Fire Breath!"),
                        new Spawn("Archdemon Malphas"),                         //He is spawning the abyss boss at the default speed..which is personally not enough for the devil but it will suffice
                        new HpLessTransition(0.95, "Fight2")                        //Once the player(s) have done 5% damage to The Devil he will go to Fight2
                        ),
                    new State("Fight2",
                        new Taunt("Still alive huh..."),
                        new TimedTransition(500, "Fight3")
                        ),
                    new State("Fight3",
                        new Taunt("Lets see how long you will survive..."),
                        new Shoot(20, 6, 2, 1, 180, coolDown: 5000),
                        new Shoot(20, 6, 2, 1, 170, coolDown: 5000, coolDownOffset: 500),
                        new Shoot(20, 6, 2, 1, 160, coolDown: 5000, coolDownOffset: 1000),
                        new Shoot(20, 6, 2, 1, 150, coolDown: 5000, coolDownOffset: 1500),
                        new Shoot(20, 6, 2, 1, 140, coolDown: 5000, coolDownOffset: 2000),
                        new Shoot(20, 6, 2, 1, 130, coolDown: 5000, coolDownOffset: 2500),
                        new Shoot(20, 6, 2, 1, 120, coolDown: 5000, coolDownOffset: 3000),
                        new Shoot(20, 6, 2, 1, 110, coolDown: 5000, coolDownOffset: 3500),
                        new Shoot(20, 6, 2, 1, 100, coolDown: 5000, coolDownOffset: 4000),
                        new Shoot(20, 6, 2, 1, 90, coolDown: 5000, coolDownOffset: 4500),               //This is the Devil shooting in a simple to write pattern...test this to see what it does :)
                        new Shoot(20, 6, 2, 1, 190, coolDown: 5000, coolDownOffset: 500),
                        new Shoot(20, 6, 2, 1, 200, coolDown: 5000, coolDownOffset: 1000),
                        new Shoot(20, 6, 2, 1, 210, coolDown: 5000, coolDownOffset: 1500),
                        new Shoot(20, 6, 2, 1, 220, coolDown: 5000, coolDownOffset: 2000),
                        new Shoot(20, 6, 2, 1, 230, coolDown: 5000, coolDownOffset: 2500),
                        new Shoot(20, 6, 2, 1, 240, coolDown: 5000, coolDownOffset: 3000),
                        new Shoot(20, 6, 2, 1, 250, coolDown: 5000, coolDownOffset: 3500),
                        new Shoot(20, 6, 2, 1, 260, coolDown: 5000, coolDownOffset: 4000),
                        new Shoot(20, 6, 2, 1, 270, coolDown: 5000, coolDownOffset: 4500),
                        new HpLessTransition(0.66, "Fight4")
                        ),
                    new State("Fight4",
                        new Taunt("Your only testing my patience"),
                        new Spawn("Archdemon Malphas"),
                        new Spawn("Oryx the Mad God 2"),                //Spawning alot more since The Devil is the god of the hell
                        new Spawn("White Demon of the Abyss"),
                        new Shoot(20, 6, 60, 2, 0, coolDown: 3000),
                        new Shoot(20, 6, 60, 2, 10, coolDown: 3000, coolDownOffset: 500),
                        new Shoot(20, 6, 60, 2, 20, coolDown: 3000, coolDownOffset: 1000),
                        new Shoot(20, 6, 60, 2, 30, coolDown: 3000, coolDownOffset: 1500),      //The Devil is now shooting in a sprial pattern...test to see the fire works :)
                        new Shoot(20, 6, 60, 2, 40, coolDown: 3000, coolDownOffset: 2000),
                        new Shoot(20, 6, 60, 2, 50, coolDown: 3000, coolDownOffset: 2500),
                        new HpLessTransition(0.33, "Fight5")
                        ),
                    new State("Fight5",                                             //Learn my friend so you can make your own :)
                        new Taunt("I...Will Not...Lose..."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1500, "Fight6")
                        ),
                    new State("Fight6",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("But you will need to code the rest..."),
                        new TimedTransition(1500, "Fight7")
                        ),
                    new State("Fight7",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Learn my friend..."),
                        new TimedTransition(1500, "Fight8")
                        ),
                    new State("Fight8",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("For the better of the P'server Nation")       //For the better of the P'server Nation you must learn :)
                        )
                    )
                )
            );
    }
}
